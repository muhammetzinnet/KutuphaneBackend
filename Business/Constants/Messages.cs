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
        internal static string CategoryAdded;
        internal static string CategoryNameAlreadyExists;
        internal static string CategoryDeleted;
        internal static string CategoryUpdated;
        internal static string KindAdded;
        internal static string KindUpdated;
        internal static string KindDeleted;
    }
}
