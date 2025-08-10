# Tren Rezervasyon API

Bu proje, tren rezervasyon iþlemlerini yönetmek için geliþtirilmiþ bir .NET 8 Web API projesidir.

## Özellikler

- Tren ve vagon bazýnda rezervasyon yapabilme
- Kiþileri farklý vagonlara yerleþtirebilme opsiyonu
- Vagon doluluk oraný kontrolü
- PostgreSQL veritabaný entegrasyonu
- Swagger UI ile API dokümantasyonu

## Baþlangýç

### Gereksinimler

- .NET 8.0 SDK
- PostgreSQL
- Visual Studio 2022 veya VS Code

### Kurulum

1. Repoyu klonlayýn:

    ```bash
    git clone https://github.com/MuhammedCubukcu/TrainReservationApi.git
    ```

2. Proje dizinine gidin:

    ```bash
    cd TrainReservationApi
    ```

3. Gerekli baðýmlýlýklarý yükleyin:

    ```bash
    dotnet restore
    ```

4. Veritabaný migrasyonlarýný uygulayýn:

    ```bash
    dotnet ef database update
    ```

5. Uygulamayý baþlatýn:

    ```bash
    dotnet run
    ```

API, varsayýlan olarak `https://localhost:5001` adresinde çalýþacaktýr.

### Test

Postman veya benzeri bir araç kullanarak API uç noktalarýný test edebilirsiniz.

### Dökümantasyon

Swagger UI entegrasyonu sayesinde, API dökümantasyonu otomatik olarak oluþturulmakta ve güncel tutulmaktadýr. Uygulama çalýþýrken `https://localhost:5001/swagger` adresinden Swagger UI'a ulaþabilirsiniz.

## Tüm Rezervasyonlarý Listeleme

**Endpoint:** `GET /Rezervasyon`

## Teknik Detaylar

- .NET 8.0
- Entity Framework Core
- PostgreSQL
- Swagger/OpenAPI
- Repository Pattern
- Dependency Injection

## Katkýda Bulunma

1. Fork'layýn
2. Feature branch oluþturun (`git checkout -b feature/amazing-feature`)
3. Deðiþikliklerinizi commit edin (`git commit -m 'feat: Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluþturun

## Lisans

[MIT License](LICENSE)

## Ýletiþim

Proje Sorumlusu - [@MuhammedCubukcu](https://github.com/MuhammedCubukcu)

Proje Linki: [https://github.com/MuhammedCubukcu/TrainReservationApi](https://github.com/MuhammedCubukcu/TrainReservationApi)