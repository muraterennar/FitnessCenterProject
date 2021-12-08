using Core.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Conctants
{
    public static class Messages
    {
        public static string Userregistered = "Başarıyla Üye Olundu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Yanlış Şifre! Lütfen Tekrar Deneyin";
        public static string SuccessfulLogin = "Başarıyla Giriş Yapıldı, Hoş Geldiniz";
        public static string UserAlreadyExists = "Bu Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UsersListed = "Kullanıcılar Başarıyla Listelendi";
        public static string MembershipAdded = "Abonelik Başarıyla Eklendi";
        public static string MembershipDeleted = "Abonelik İptal Edildi";
        public static string MembershipNotUpdated = "Böyle Üyelik Yok!";
        public static string MembershipUpdated = "Üyelik Güncellendi";
        public static string MembershipDetailsListed = "Üyelik Detayları Listelendi";
        public static string AuthorizantionDenied = "Yetkilendirme reddedildi";
    }
}
