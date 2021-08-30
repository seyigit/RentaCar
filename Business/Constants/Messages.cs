using Core.Utilities.Jwt;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddToCar = "Ürün Eklendi";
        public static string AddToCarInvalid = "Bir hata oluştu ürün eklenemedi.";
        public static string UpdateToCarMessage = "Ürün Update Edildi";
        public static string UpdateToCarInvalidMessage = "Bu ürün eklenemez.";
        public static string DeleteToCarSuccessMessage = "Ürün başarıyla silindi";
        public static string GetAllFilterSuccessMessage = "Ürünler başarıyla listelendi";
        public static string CarDetailSuccessMessage = "Detaylar başarılı bir şekilde listelendi.";
        public static string GetByIdFilterSuccessMessage ="Id ye göre ürün listelendi.";
        public static string AddToBrandSuccessMessage = "Marka Başarıyla Eklendi.";
        public static string DeleteToBrandSuccessMessage = "Marka Başarıyla Silindi.";
        public static string UpdateToBrandMessage = "Marka Güncellendi.";
        public static string AddToColor = "Renk Eklendi.";
        public static string DeleteToColorSuccessMessage = "Renk başarıyla silindi.";
        public static string UpdateToColorSuccessMessage = "Renk başarıyla güncellendi.";
        public static string InvalidFilter = "Bu saate ürün girilemez.";
        public static string AddToUser;
        public static string DeleteToUserSuccessMessage;
        public static string UpdateToUserMessage;
        public static string AddToCustomerSuccessMessage;
        public static string DeleteToCustomerSuccessMessage;
        public static string UpdateToCustomerSuccessMessage;
        public static string AddToRentalSuccessMessage;
        public static string DeleteToRentalSuccessMessage;
        public static string UpdateToRentalSuccessMessage;
        public static string AddToRentalInvalid =" Araç teslim alınmadı kiralama yapılamaz.";
        public static string AddToCarImageSuccessMessage="Resim Başarılı bir şekilde eklendi.";
        public static string DeleteToCarImageSuccessMessage="Resim başarılı bir şekilde silindi.";
        public static string UpdateToCarImageSuccessMessage= "Resim başarılı bir şekilde güncellendi.";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError = "Password Hatalı";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string ErrorUSerExist="Bu email ile daha önce kayıt olunmuş";
        public static string UserRegistered="Kullanıcı Başarıyla Kaydedildi.";
        public static string AccessTokenCreate = "Access Token Başarıyla Oluşturuldu.";
    }
}
