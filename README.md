Bu projede müşteriler sisteme araba yükleyip, araba satın alabilmektedir.

Kişi bazlı alınan satılan arabalar,toplam satışlar gibi farklı listelemeler yapıldı.

Api-DataAccess-Business-Entities-Core katmanları üzerinden işlemler yapıldı.

Müşteriler arabayı tek seferde veya parçalı bir şekilde ödeme yaparak alabilmektedir.

Core katmanında repositorylerin generic yapısı oluşturuldu ve bu yapı tüm repositorylerde kullanıldı. 
DataAccess katmanında Db ile bağlantımız oluşturuldu. Business katmanında servislerimiz yazıldı. 
Yapılacak her işlemin servisi bu katmanda oluşturuldu. Entities katmanında tabloda göreceğimiz modellerimiz oluşturuldu. 
Api katmanında da kullanıcının işlemleri yapabileceği,görüntüleyebileceği endpointler yazıldı.

Projede database işlemleri için EntityFramework kullanıldı. Database olarak Sql kullanıldı.
