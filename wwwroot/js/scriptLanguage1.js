$(document).ready(function () {

    var arrLang = {

        'tr': {
            '0': 'Sil',
            '1': 'Yemek Tarifleri',
            '2': 'Hakkımızda',
            '3': 'Biz Kimiz',
            '4': 'Bu bir deneme mesajıdır.',
            '5': 'Bizimle iletişime Geçin',
            '6': 'Görüşleriniz bizim için çok değerli!',
            '7': 'İsim',
            '8': 'Soy isim',
            '9': 'Email',
            '10': 'Açıklama',
            '11': "Kaydet",
            '12': "Kullanıcılar",
            '13': 'Yeni Kullanıcı',
            '14': 'Kullanıcı Adı',
            '15': 'Oluşturulma Tarihi',
            '16': 'Rol',
            '17': 'Kullanıcı Düzenle',
            '18': 'Kullanıcı Oluştur',
            '19': 'Şifre',
            '20': 'Yeniden Şifre',
            '21': 'Kategoriler',
            '22': 'Yeni Kategori',
            '23': 'Kategori Düzenle',
            '24': 'Kategori Oluştur',
            '25': 'Giriş Yap',
            '26': 'Profil Düzenle',
            '27': 'Kayıt Ol',
            '28': 'Yemek Tarifi Ekle',
            '29': 'Yemek İsmi',
            '30': 'Yemeğin Kategorisi',
            '31': 'Yemeğin tarifi',
            '32': 'Yemek Düzenle',
            '33': 'Iletisim',
            '34': 'Yeni Kullanıcı ekle',
            '35': 'Yemekler',
            '36': 'Yeni Yemek Ekle',
            '37': 'Güncelleme Tarihi',
            '38': 'Yorumlar',
            '39': 'Yorum',
            '40': 'Tarifi',
            '41': 'Yorum EKle',
            '42': 'Düzenle',
            '43': 'Sil',
            '44': 'Ben Ebubekir Mert. Sakarya Üniveristesi Bilgisayar Mühendisliği okuyorum.',
            '45': 'Ben Elman Muradov. Sakarya Üniveristesi Bilgisayar Mühendisliği okuyorum.',
            '46': 'Yemek Tarif Sitesi',
            '47': 'Tüm hakları saklıdır',
            '48': 'Erişim Engellendi',
            '49': 'İlgili sayfaya erişiminiz yoktur.Lütfen üye olun.'

        },


        'en': {
            '0': 'Delete',
            '1': 'Recipes',
            '2': 'About Us',
            '3': 'Who We Are',
            '4': 'This is a test message.',
            '5': 'Contact Us',
            '6': 'Your feedback is very valuable to us!',
            '7': 'Name',
            '8': 'Last name',
            '9': 'Email',
            '10': 'Description',
            '11': "Save",
            '12': "Users",
            '13': 'New User',
            '14': 'Username',
            '15': 'Creation Date',
            '16': 'Role',
            '17': 'Edit User',
            '18': 'Create User',
            '19': 'Password',
            '20': 'Reset Password',
            '21': 'Categories',
            '22': 'New Category',
            '23': 'Edit Category',
            '24': 'Create Category',
            '25': 'Log In',
            '26': 'Edit Profile',
            '27': 'Register',
            '28': 'Add Recipe',
            '29': 'Food Name',
            '30': 'Category of Food',
            '31': 'recipe',
            '32': 'Edit Meal',
            '33': 'Contact',
            '34': 'Add New User',
            '35': 'Meals',
            '36': 'Add New Food',
            '37': 'Date of Update',
            '38': 'Comments',
            '39': 'Comment',
            '40': 'Recipe',
            '41': 'Add a Note',
            '42': 'Edit',
            '43': 'Delete',
            '44': "I'm Ebubekir Mert. I'm studying Computer Engineering at Sakarya University.",
            '45': "I'm Elman Muradov. I'm studying Computer Engineering at Sakarya University.",
            '46': 'Recipe Site',
            '47': 'All rights reserved',
            '48': 'Access Denied',
            '49': 'You do not have access to the relevant page. Please register.'
        },


    };



    $('.dropdown-item').click(function () {
        localStorage.setItem('dil', JSON.stringify($(this).attr('id')));
        location.reload();
    });

    var lang = JSON.parse(localStorage.getItem('dil'));

    if (lang == "en") {
        $("#drop_yazı").html("English");
    }
    else {
        $("#drop_yazı").html("Türkçe");

    }

    $('a,h5,p,h1,h2,span,li,button,h3,label').each(function (index, element) {
        $(this).text(arrLang[lang][$(this).attr('key')]);

    });

});
