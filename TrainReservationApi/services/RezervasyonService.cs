using TrainReservationApi.Data;
using TrainReservationApi.entities;
using TrainReservationApi.Models;

namespace TrainReservationApi.services
{
    public class RezervasyonService : IRezervasyonService
    {
        private readonly ReservationDbContext _context;

        public RezervasyonService(ReservationDbContext context)
        {
            _context = context;
        }

        public List<Rezervasyon> GetAllRezervasyonlar()
        {
            return _context.Rezervasyonlar.ToList();
        }

        public RezervasyonResponse RezervasyonYap(RezervasyonRequest request)
        {
            var response = new RezervasyonResponse
            {
                RezervasyonYapilabilir = false,
                YerlesimAyrinti = new List<Yerlesim>()
            };

            var kisiSayisi = request.RezervasyonYapilacakKisiSayisi;
            var vagonlar = request.Tren.Vagonlar
                .Select(v => new
                {
                    Vagon = v,
                    BosKoltuk = (int)Math.Floor(v.Kapasite * 0.7) - v.DoluKoltukAdet
                })
                .ToList();

            if (request.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                int kalanKisi = kisiSayisi;
                foreach (var v in vagonlar)
                {
                    if (v.BosKoltuk <= 0) continue;
                    int yerlestirilecek = Math.Min(kalanKisi, v.BosKoltuk);
                    if (yerlestirilecek > 0)
                    {
                        response.YerlesimAyrinti.Add(new Yerlesim
                        {
                            VagonAdi = v.Vagon.Ad,
                            KisiSayisi = yerlestirilecek
                        });
                        kalanKisi -= yerlestirilecek;
                    }
                    if (kalanKisi == 0) break;
                }
                response.RezervasyonYapilabilir = kalanKisi == 0;
                if (!response.RezervasyonYapilabilir)
                    response.YerlesimAyrinti.Clear();
            }
            else
            {
                var uygunVagon = vagonlar.FirstOrDefault(v => v.BosKoltuk >= kisiSayisi);
                if (uygunVagon != null)
                {
                    response.RezervasyonYapilabilir = true;
                    response.YerlesimAyrinti.Add(new Yerlesim
                    {
                        VagonAdi = uygunVagon.Vagon.Ad,
                        KisiSayisi = kisiSayisi
                    });
                }
            }

            if (response.RezervasyonYapilabilir)
            {
                foreach (var yerlesim in response.YerlesimAyrinti)
                {
                    var rezervasyon = new Rezervasyon
                    {
                        TrenAdi = request.Tren.Ad,
                        VagonAdi = yerlesim.VagonAdi,
                        KisiSayisi = yerlesim.KisiSayisi,
                        Tarih = DateTime.Now
                    };
                    _context.Rezervasyonlar.Add(rezervasyon);
                }
                _context.SaveChanges();
            }

            return response;
        }
    }
}

