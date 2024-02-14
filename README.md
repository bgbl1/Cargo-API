# BynrCargo API

BynrCargo API, kargo teslimatlarını yönetmek için bir web API'si sağlar. Bu API, teslimatların listelenmesi, yeni teslimatların eklenmesi, teslimat durumlarının alınması ve teslimatların iptal edilmesi gibi temel işlevleri destekler.

## Kullanım

Bu API, HTTP istekleri aracılığıyla kullanılabilir. İşlevler ve kullanım detayları aşağıda açıklanmıştır.

### Teslimat Listesi Al

GET isteğiyle `/Delivery/List` adresine yapılan istek, mevcut tüm teslimatların listesini alır.


### Teslimat Ekle

POST isteğiyle `/Delivery/Add` adresine teslimat bilgileri JSON formatında gönderilerek yeni bir teslimat eklenir.


### Teslimat Durumunu Al

GET isteğiyle `/Delivery/Status/{DeliveryId}` adresine yapılan istek, belirli bir teslimatın durumunu alır.


### Teslimatı İptal Et

DELETE isteğiyle `/Delivery/Cancel/{DeliveryId}` adresine yapılan istek, belirli bir teslimatı iptal eder.


## Geliştirme

Bu proje, ASP.NET Core ve C# dili kullanılarak geliştirilmiştir. 

