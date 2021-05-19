using Core.Entities.Concreate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BookAdded = "Kitap eklendi.";
        public static string BookNameInvalid = "Kitap ismi geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda.";
        public static string BooksListed = "Kitaplar Listelendi.";
        public static string BookNameAlreadyExists = "Bu isimda başka bir kitap mevcuttur.";
        public static string AuthorizationDenied = "Bu işlemi yapmaya yetkiniz yok.";
        public static string UserRegistered = "Bu kullanıcı sisteme kayıtlı.";
        public static string UserNotFound = "Böyle bir kullanıcı mevcut değil.";
        public static string PasswordError = "Hatalı şifre girdiniz.";
        public static string SuccessfulLogin = "Sistteme giriş başarılı.";
        public static string UserAlreadyExists = "Sistemde böyle bir kullanıcı mevcut.";
        public static string AccessTokenCreated = "Sisteme erişim oluşturuldu.";
        public static string BookDeleted = "Kitap ismi silindi";
        public static string BookUpdated = "Kitap ismi güncellendi";
        public static string CategoryAdded = "Yeni kategori eklendi";
        public static string CategoryNameAlreadyExists = "Eklemek istediğiniz kategori zaten var";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryUpdated = "Mevcut katagori güncellendi";
        public static string KindAdded = "Yeni kitap türü eklendi";
        public static string KindUpdated = "Mevcut kitap türü güncellendi";
        public static string KindDeleted = "Kitap türü silindi";
        public static string KindsListed = "Kitap türü listelendi.";
        public static string LendsListed = "Kitabın verilişine göre listelendi";
        public static string BookLendsListed = "Kitap kişiye verilene göre listelendi.";
        public static string ReturnBookListed = "Kitabın dönüşüne görre listelendi.";
        public static string BooksIdListed = "Kitab ID' ye göre listelendi.";
        public static string BooksLendListed = "Kitap kiralanmaya göre listelendi.";
        public static string BooksKindListed = "Kitap türe göre listelendi";
        public static string CategoryListed = "Kategori listelendi";
        public static string CategoryNameListed = "Katagori isme göre listelendi.";
        public static string LendAdded = "Kitap ödünç verme eklendi.";
        public static string LendDayCantbePast = "Kitabın geri alma günü geçmiş olabilir.";
        public static string BookOnRent = " Kitap verildi.";
        public static string RentalNotComeBack = "Kitap geri gelmedi.";
        public static string LendDeleted = "Ödünç verme silindi.";
        public static string LendUpdated = "Ödünç verme güncellendi.";
        public static string CustomerAdded = "Yeni kişi eklendi.";
        public static string CustomerDeleted = "Kişi silindi.";
        public static string CustomerUpdated = "Kişi güncellendi";
        public static string CustomerListed = "Kullanıcılar listelendi";
    }
}
