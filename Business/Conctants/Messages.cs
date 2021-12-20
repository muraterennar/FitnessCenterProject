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
        public static string MembershipsListed = "Üyelikler Listelendi";
        public static string MembershipListed = "Üyelik Listelendi";
        public static string SubsAdded = "Abonelik Eklendi";
        public static string SubsDeleted = "Abonelik Silindi";
        public static string SubsNotUpdated = "Abonelik Güncellenemedi";
        public static string SubsUpdated = "Abonelik Güncellendi";
        public static string SubscriptionsListed = "Abonelikler Listelendi";
        public static string SubscriptionListed = "Abonelik Listelendi";
        public static string ChekIfMembershipDate = "Üyelik tarihi Doğrulandı";
        public static string UserIdAlreadyExists = "Eklenen Kişinin Üyeliği devam Etmekte";
        public static string OnGoingSubscription = "Üyeliğiniz Devam Etmekte";
        public static string PersonHasNoMembership = "Girilen Kişinin Üyeliği Bulunmamaktadır";
    }
}
