using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string UserRegistered = "Kayıt başarılı";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AuthorizationDenied = "Yetkiniz yeterli değil";

        public static string BookImageDeleted = "Kitap resmi silindi";
        public static string BookImageUpdated = "Kitap resmi güncellendi";

        public static string ParametersNotFound = "Seçimlerinizle alakalı kitap yok";
    }
}
