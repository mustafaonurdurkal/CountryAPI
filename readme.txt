API Proje yapısında;
-> * Öncelikle Farklı Dosya Tipleri ile çalışabilmeyi kolaylaştırmak amaçlı bir interface yazıldı.
   * Bu interface dosyadan okuma ve dosya yazma fonksiyon tanımlarını barındırıyor.
   * Bu interfaceden Csv ve XML operasyonlarını yapan 2 adet class kalıtıldı bu classlar ile Read ve Write
	operasyonları gerçekleştiriliyor.

-> *Filtreleme operasyonları için bir interface yazıldı ve buradan Filtreleme operasyonlarını kalıtan bir
	bir class yazıldı.
   *Bu class cityName , districtName propertylerine göre bir filtreleme operasyonu gerçekleştiriyor.
   
-> *Sıralama operasyonları için bir interface yazıldı bu interfaceden 2 adet class kalıtıldı.
   *Custom Sortingde QuickSort algoritması kullanıldı O(nlgn) zaman karmaşıklığı ile parametreye göre asc veya desc 
	sıralama yapılabiliyor. Bu sıralama cityName veya districtName e göre yapılabiliyor.Ayrıca önce cityleri sıralayıp
	sonrasında bu cityleri gruplayıp her bir grup ögesini districtlere göre kendi içinde sıralayan bir fonksiyon mevcuttur.
   *Ayrıca RegularSorting isimli classta LINQ operasyonları ile .NET kütüphanesi kullanarakta sıralamala fonksiyonlarıda opsiyonel 
	yapılmıştır.

-> *Test projesinde case dökümanında bulunan durumların testleri ExpectedTest classında değerlendirildi.
   *Ayrıca otherTest classında da dosya okuma yazma operasyonları gibi diğer fonksiyonların testini yapıldı.
   *TestCaselerinde kıyaslama yapılabilecek iç fonksiyonlar TestUtil classında toparlandı.
	

--3RD Part Kütüphane olarak CSVHelper kullanıldı. Bu kütüphane kullanılmadan StreamReader nesnesi kullanarak satır satır
 	CSV dosyası işlemleri yapılabilirdi. Ancak kullanım kolaylığı açısından bu kütüphane tercih edildi.
--XML operasyonları için .NET içeriğinde mevcut System.Xml.Linq kütüphanesi kullanıldı 3rd kütüphaneye ihtiyaç olmadı.


Talimatlar:
 --Zip Dosyasını çıkarın
 --Visual Studio ile CountryAPI.sln dosyasını çalıştırın.

  