using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem Bakımda.";
        public static string Listed = "Listelendi.";
        
        public static string CarAdded = "Araba Eklendi.";
        public static string CarDeleted = "Araba Silindi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarListed = "Araba Listelendi.";
        public static string CarsListed = "Arabalar Listelendi.";
        public static string CarNameAlreadyExist = "Bu isimde başka bir araba adı zaten var.";
        public static string CarAddError = "Araba adın 2 karakterden uzun ve günlük ücreti 0'dan büyük olmalıdır.";

        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";
        public static string ColorsListed = "Renkler Listelendi.";
        public static string ColorListed = "Renk Listelendi.";

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string BrandsListed = "Markalar Listelendi.";
        public static string BrandListed = "Marka Listelendi.";

        public static string RentalAdded = "Kiralama Eklendi.";
        public static string RentalDeleted = "Kiralama Silindi.";
        public static string RentalUpdated = "Kiralama Güncellendi.";
        public static string RentalsListed = "Kiralamalar Listelendi.";
        public static string RentalListed = "Kiralama Listelendi.";
        public static string RentalCarError = "Araç Kiralanamaz.";

        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        public static string UsersListed = "Kullanıcılar Listelendi.";
        public static string UserListed = "Kullanıcı Listelendi.";

        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";
        public static string CustomersListed = "Müşteriler Listelendi.";
        public static string CustomerListed = "Müşteri Listelendi.";

        public static string CarImageAdded = "Araç Resmi Eklendi.";
        public static string CarImageDeleted = "Araç Resmi Silindi.";
        public static string CarImageUpdated = "Araç Resmi Güncellendi.";
        public static string CarImagesListed = "Araç Resimleri Listelendi.";
        public static string CarImageListed = "Araç Resmi Listelendi.";
        public static string CarImageLimitExceeded = "Bir araca en fazla 5 resim yüklenebilir.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";

    }
}
