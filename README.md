# Tren Rezervasyon API

Bu proje, tren rezervasyon i�lemlerini y�netmek i�in geli�tirilmi� bir .NET 8 Web API projesidir.

## �zellikler

- Tren ve vagon baz�nda rezervasyon yapabilme
- Ki�ileri farkl� vagonlara yerle�tirebilme opsiyonu
- Vagon doluluk oran� kontrol�
- PostgreSQL veritaban� entegrasyonu
- Swagger UI ile API dok�mantasyonu

## Ba�lang��

### Gereksinimler

- .NET 8.0 SDK
- PostgreSQL
- Visual Studio 2022 veya VS Code

### Kurulum

1. Repoyu klonlay�n:

    ```bash
    git clone https://github.com/MuhammedCubukcu/TrainReservationApi.git
    ```

2. Proje dizinine gidin:

    ```bash
    cd TrainReservationApi
    ```

3. Gerekli ba��ml�l�klar� y�kleyin:

    ```bash
    dotnet restore
    ```

4. Veritaban� migrasyonlar�n� uygulay�n:

    ```bash
    dotnet ef database update
    ```

5. Uygulamay� ba�lat�n:

    ```bash
    dotnet run
    ```

API, varsay�lan olarak `https://localhost:5001` adresinde �al��acakt�r.

### Test

Postman veya benzeri bir ara� kullanarak API u� noktalar�n� test edebilirsiniz.

### D�k�mantasyon

Swagger UI entegrasyonu sayesinde, API d�k�mantasyonu otomatik olarak olu�turulmakta ve g�ncel tutulmaktad�r. Uygulama �al���rken `https://localhost:5001/swagger` adresinden Swagger UI'a ula�abilirsiniz.

## T�m Rezervasyonlar� Listeleme

**Endpoint:** `GET /Rezervasyon`

## Teknik Detaylar

- .NET 8.0
- Entity Framework Core
- PostgreSQL
- Swagger/OpenAPI
- Repository Pattern
- Dependency Injection

## Katk�da Bulunma

1. Fork'lay�n
2. Feature branch olu�turun (`git checkout -b feature/amazing-feature`)
3. De�i�ikliklerinizi commit edin (`git commit -m 'feat: Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request olu�turun

## Lisans

[MIT License](LICENSE)

## �leti�im

Proje Sorumlusu - [@MuhammedCubukcu](https://github.com/MuhammedCubukcu)

Proje Linki: [https://github.com/MuhammedCubukcu/TrainReservationApi](https://github.com/MuhammedCubukcu/TrainReservationApi)