using System.Collections.Generic;
using TrainReservationApi.entities;
using TrainReservationApi.Models;

namespace TrainReservationApi.services
{
    public interface IRezervasyonService
    {
        List<Rezervasyon> GetAllRezervasyonlar();
        RezervasyonResponse RezervasyonYap(RezervasyonRequest request);
    }
}
