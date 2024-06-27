# Demirbaş ve Zimmet Takip uygulaması
Bu proje, C# Windows Forms kullanılarak geliştirilmiş bir Demirbaş ve Zimmet kayıtları yönetim uygulamasıdır. Adliye Bilgi İşlem dairesi için geliştirilmiş olup, program içerisinde kurumda bulunan demirbaşlar, personeller
veritabanına kayıt edilebilmekte ve personellere ilgili demirbaşın zimmetlenebilmesi sağlanmaktadır.

## 🔹 Özellikler
- Program kullanıcısı, kurumdaki çalışanları bir arayüzde kaydedebilir,silebilir ve güncelleyebilir.
- Kurumdaki demirbaşlar bir arayüzde kaydedilebilir,silinebilir ve güncellenebilir.
- Zimmetler için ayrı tablo bulunmaktadır, bir demirbaş yalnızca bir kullanıcıya zimmetlenebilir, bir kullanıcıya birden fazla zimmetli demirbaş olabilir.
- Demirbaşlar,Personeller ve Zimmetler tabloları için Excel formatında çıktı alınabilmektedir.
- Ayrıca tabloda seçili zimmet için Zimmet fişi çıkarma özelliği mevcuttur. Excel formatında Zimmet fişi çıktısı alınabilmektedir.

## 🔧 Kurulum
1. Projeyi GitHub'dan veya ZIP olarak indirin.
2. Visual Studio'da `zimmetTakip.sln` dosyasını açın.
3. Gerekirse, NuGet üzerinden `Microsoft.Office.Interop.Excel` paketini projeye ekleyin.
4. Projeyi derleyin ve çalıştırın.

Projede .NET Framework 4.5 kullanılmıştır. Ayrıca 4.7.2 veya 4.8 sürümleri ile de uyumlu çalışabilir.

## 💻 Kullanılan Teknolojiler
- Visual Studio 2022
- .NET Framework 4.5
- Veriler CSV formatında tutulmuştur, DBMS kullanılmamıştır.
- **LINQ (Language Integrated Query):** Veri sorgulamaları için kullanılmıştır, özellikle personel ve demirbaş verilerinin filtrelenmesinde kullanılır.

## 📦 Bağımlılıklar
- **NuGet Paketleri:**
  - **Microsoft.Office.Interop.Excel**: Excel dosyaları oluşturmak ve verileri dışa aktarmak için kullanılmıştır.
    - **Sürüm**: 15.0.4795.1001

## 📸 Ekran Görüntüleri

<img src="https://github.com/AbdulhalikAkdeniz/Demirbas-ve-Zimmet-Takip-WinForms/assets/139945380/08d4b0ae-4f08-4642-b78c-0aceb16d02a0" alt="db" width="600"/>
<img src="https://github.com/AbdulhalikAkdeniz/Demirbas-ve-Zimmet-Takip-WinForms/assets/139945380/3d811bdc-91d5-47dd-bd29-f1916b39d224" alt="zm" width="800"/>



## 📧 İletişim
abdulhalikakdeniz08@gmail.com
