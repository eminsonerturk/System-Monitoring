$(document).ready(function () {

    // Tıklanan grupta bulunan kişileri listeleme
    $('.groupName').click(function () {
        // Yükleme "gif"i gösteriliyor.
        $('#loadingMembers').show();

        // Grup seçilince searchTextBox'ların içi temizlenmek istenirse.
        // $('.searchTextBox').val("");

        // Önceki grup listesi ekrandan siliniyor.
        $('#membersList').empty();

        // Önceki üyelik listesi ekrandan siliniyor.
        $('#membershipList').empty();

        var groupName = $(this).text();

        var membersList = document.getElementById('membersList');
        var groupHeader = document.getElementById('groupHeader');

        //Seçilen grup mavi yapılıyor.
        $("li.groupName").removeClass("active");
        $(this).addClass("active");

        // Üye ismi listesindeki grup başlığı siliniyor.
        groupHeader.innerText = "";

        // Controller'ı çağıran Ajax metodu
        // GET: Search/MembersOfGroup
        if (groupName != '') {
            $.ajax({
                url: 'MembersOfGroup',
                data: { 'groupName': groupName },
                type: "POST",
                cache: false,
                datatype: 'json',
                success: function (data) {
                    if (data.length > 0) {
                        // Kullanıcı isimleri listeye ekleniyor.
                        for (i = 0; i < data.length; i++) {
                            var li = document.createElement("li");
                            li.setAttribute("class", "userName list-group-item");
                            // İsimlere, "ToolTip" olarak kullanıcı mail adresi ekleniyor.
                            li.setAttribute("title", data[i].userMail);

                            // Kullanıcı, grupta "admin" ise "bold" font ile yazılıyor ve sağ tarafına yıldız simgesi ekleniyor.
                            if (data[i].isAdmin) {
                                li.innerHTML = "<span class='glyphicon glyphicon-user' style='color:RGB(56,133,54);'></span> <b>" + data[i].userName + "</b><span class='glyphicon glyphicon-star starOfAdmin'></span>";
                            }
                            else {
                                li.innerHTML = "<span class='glyphicon glyphicon-user' style='color:RGB(56,133,54);'></span> " + data[i].userName;
                            }

                            membersList.appendChild(li);
                        }
                    }
                    else {
                        // Controller'a grup ismi gönderilince, hiç bir üye ismi dönmezse
                        var paragraph = document.createElement("p");
                        paragraph.appendChild(document.createTextNode("Bu grupta üye bulunmamaktadır."));
                        membersList.appendChild(paragraph);
                    }
                },
                error: function () {
                    var warning = document.createElement("p");
                    warning.appendChild(document.createTextNode("Arama yapılırken bir hata oluştu. Lütfen tekrar deneyiniz."));
                    membersList.appendChild(warning);
                    $('#loadingMembers').hide();
                },
                complete: function () {
                    // İşlem tamamlanınca, grup başlığı listenin tepesine yazdırılıyor.
                    // "Loading" gif'i ekrandan kaldırılıyor.
                    $('#loadingMembers').hide();
                    groupHeader.innerText = groupName + ":";
                }
            });
        }
    });

    // Tıklanan kişinin kayıtlı olduğu grupları listeleme
    $('body').on('click', '.userName', function () {
        // Yükleme "gif"i gösteriliyor.
        $('#loadingGroups').show();

        // Kişi seçilince searchTextBox'ların içi temizlenmek istenirse.
        //$('.searchTextBox').val("");

        // Önceki üyelik listesi ekrandan siliniyor.
        $('#membershipList').empty();

        var userName = $(this).text();
        var membershipList = document.getElementById('membershipList');

        var memberName = document.getElementById('memberName');
        memberName.innerText = "";

        // Seçilen kullanıcı adı mavi yapılıyor.
        $("li.userName").removeClass("active");
        $(this).addClass("active");

        // userName "empty" değilse, Controller'a parametre olarak gönderiliyor.
        if (userName != '') {
            var warning = "Herhangi bir kayıt bulunamadı.";
            // Controller ile Ajax güncellemesi yapan metoda, "userName" ve kayıt bulunamadığında
            // gösterilecek uyarı text'i parametre olarak gönderiliyor.
            $.findMembershipsOfUser(userName, warning);
        }
    });

    // Search Filter (Groups)
    $('.searchTextBox').keyup(function () {
        var searchText = this.value;

        // String'deki Türkçe karakterler, İngilizce karakterlere çevriliyor.
        searchText = $.toEnglish(searchText);

        var searchTextBoxId = jQuery(this).attr("id");

        // Seçilen searchTextBox, group'lar içinse grup listesinde, member'lar içinse
        // member listesinde filtreleme yapılıyor.
        if (searchTextBoxId == 'groupSearchTextBox') {
            // Grup listesinde, security ve mail grupları olmak üzere 2 adet "ul" olduğundan
            // filtrelemeyi yapacak olan metod 2 kere çağrılıyor.
            $.searchText("securityGroups", searchText);
            $.searchText("mailGroups", searchText);
        }
        if (searchTextBoxId == 'memberSearchTextBox') {
            $.searchText("membersList", searchText);
        }
    });

    // Arama ve "Highlight" işlemini yapan fonksiyon
    $.searchText = function (listType, searchText) {
        // String'deki tüm karakterler, küçük harfe döndürülüyor.
        var searchTextLower = searchText.toLowerCase(),
            searchLength = searchText.length;

        var listId = "#" + listType + ">li";

        // Listedeki her item'a uygulanan döngü
        if (searchLength > 0) {
            $(listId).each(function () {
                var text = $(this).text(),
                         // String'deki tüm karakterler, küçük harfe döndürülüyor.
                        textLower = text.toLowerCase(),
                        textLength = text.length;

                // Listedeki string içerisinde, searchTextBox'a girilen string aranıyor.
                var index = textLower.indexOf(searchTextLower);

                // String, item içerisinde bulunursa
                if (index !== -1) {
                    var başlangıç = 0;
                    var devam = true;
                    var finalText = "";
                    var remainingSubText = "";
                    var remainingSubTextLength = textLength;

                    // Gösterilecek olan "li" elementlerinin başına, bulundukları liste tipine bağlı olarak
                    // uygun icon ekleniyor.
                    if (listType == "membersList") {
                        finalText += "<span class='glyphicon glyphicon-user' style='color:RGB(56,133,54);'></span>" + text.substr(başlangıç, index) + "<mark>" + text.substr(başlangıç + index, searchLength) + "</mark>";
                    }
                    else if (listType == "mailGroups") {
                        finalText += "<span class='glyphicon glyphicon-envelope' style='color:RGB(138,109,59);'></span>" + text.substr(başlangıç, index) + "<mark>" + text.substr(başlangıç + index, searchLength) + "</mark>";
                    }
                    else {
                        finalText += "<span class='glyphicon glyphicon-lock' style='color:RGB(169,68,66);'></span>" + text.substr(başlangıç, index) + "<mark>" + text.substr(başlangıç + index, searchLength) + "</mark>";
                    }

                    while (devam) {
                        başlangıç += index + searchLength;
                        remainingSubTextLength = textLength - (başlangıç);

                        var remainingSubText = text.substr(başlangıç);

                        index = remainingSubText.toLowerCase().indexOf(searchTextLower);

                        if (index < 0) {
                            devam = false;
                            finalText += text.substr(başlangıç);
                        }
                        else if (index == 0) {
                            finalText += "<mark>" + text.substr(başlangıç + index, searchLength) + "</mark>";
                        }
                        else {
                            finalText += text.substr(başlangıç, index) + "<mark>" + text.substr(başlangıç + index, searchLength) + "</mark>";
                        }
                    }

                    // "glyphicon-star" icon'unu bulunduran "li" elementleri, grupların "admin"lerini belirtiyor.
                    // Bu icon'u html'inde barındıran "li" elementlerinin, "search" sonucunda gösterilecek hallerinin
                    // sonuna da yıldız icon'u ekleniyor.
                    var isAdmin = $(this).html().indexOf("glyphicon-star");

                    // "li" elementinin orijinal HTML'inin sonunda "yıldız" icon'u bulunuyorsa, yani "member"sa ve "admin" ise,
                    // arama sonucunda gösterilecek "li" elemanının sonuna da yıldız icon'u ekleniyor.
                    if (isAdmin >= 0) {
                        finalText += "</b><span class='glyphicon glyphicon-star starOfAdmin'></span>";
                    }

                    $(this).html(finalText).show();
                }
                else {
                    // Girilen string'i barındırmayan item'lar gizleniyor.
                    $(this).hide();
                }
            });
        }
        else {
            $(listId).each(function () {

                if (listType == "membersList") {
                    text = "<span class='glyphicon glyphicon-user' style='color:RGB(56,133,54);'></span>" + $(this).text();
                }
                else if (listType == "mailGroups") {
                    text = "<span class='glyphicon glyphicon-envelope' style='color:RGB(138,109,59);'></span>" + $(this).text();
                }
                else {
                    text = "<span class='glyphicon glyphicon-lock' style='color:RGB(169,68,66);'></span>" + $(this).text();
                }

                var isAdmin = $(this).html().indexOf("glyphicon-star");

                // "li" elementinin orijinal HTML'inin sonunda "yıldız" icon'u bulunuyorsa, yani "member"sa ve "admin" ise,
                // arama sonucunda gösterilecek "li" elemanının sonuna da yıldız icon'u ekleniyor.
                if (isAdmin >= 0) {
                    text += "</b><span class='glyphicon glyphicon-star starOfAdmin'></span>";
                }

                $(this).html(text);
                $(this).show();
            });
        }
    }

    // Kullanıcının ismi searchTextBox'a girilince kayıtlı olduğu grupları döndüren metod
    $('#membershipSearchButton').click(function () {

        var userName = document.getElementById('membershipSearchTextBox').value;
        // Girilen kullanıcı adındaki Türkçe karakterler, İngilizce karakterlere çevriliyor.
        userName = $.toEnglish(userName);

        // "Loading" gif'i gösteriliyor.
        $('#loadingGroups').show();

        // Önceki liste ekrandan siliniyor.
        $('#membershipList').empty();

        if (userName !== "") {
            // Controller ile Ajax güncellemesi yapan metoda, "userName" ve kayıt bulunamadığında
            // gösterilecek uyarı text'i parametre olarak gönderiliyor.
            var warning = "Kullanıcı kaydı bulunamadı.";
            $.findMembershipsOfUser(userName, warning);
        }
        else {
            var warning = document.createElement("p");
            warning.appendChild(document.createTextNode("Lütfen bir kullanıcı adı giriniz."));
            membershipList.appendChild(warning);
            $('#loadingGroups').hide();
        }
    });

    // Enter'a basınca üyelik aramasının başlamasını sağlayan metod
    $('#membershipSearchTextBox').keyup(function (e) {
        var key = e.which;
        if (key == 13)  // the "enter" key code
        {
            $('button[id = membershipSearchButton]').click();
            return false;
        }
    });

    // Kullanıcının kayıtlı olduğu grupları döndüren Ajax metodu (GET: Search/MembershipsOfUser)
    /* Kullanıcı ismine tıklanarak veya kullanıcı isminin searchTextBox'a girilmesiyle,
     * üye olunan gruplar döndürüleceğinden, ve bu işlemde aynı Controller aynı yöntemle
     * kullanılacağından, her iki işlem için aynı metod kullanılıyor parametreler aracılığıyla.
     */
    $.findMembershipsOfUser = function (userName, warning) {
        $.ajax({
            url: 'MembershipsOfUser',
            data: { 'userName': userName },
            type: "POST",
            cache: false,
            datatype: 'json',
            success: function (data) {
                if (data.length > 0) {
                    // Grup isimleri listeye ekleniyor.
                    for (i = 0; i < data.length; i++) {
                        var li = document.createElement("li");
                        li.className = "list-group-item";

                        // Kullanıcının kayıtlı olduğu gruplar listelenirken, "security" veya "mail" grubu olmasına göre
                        // en başa grup icon'u ekleniyor.
                        if (data[i].isSecurityGroup) {
                            li.innerHTML = "<span class='glyphicon glyphicon-lock' style='color:RGB(169,68,66);'></span> " + data[i].groupName;
                        }
                        else {
                            li.innerHTML = "<span class='glyphicon glyphicon-envelope' style='color:RGB(138,109,59);'></span> " + data[i].groupName;
                        }

                        membershipList.appendChild(li);
                    }

                    // Toplamda, kullanıcının kayıtlı olduğu grup sayısı, en alta yazılıyor.
                    var membershipCount = document.createElement("p");
                    membershipCount.setAttribute("id", "membershipCount");
                    membershipCount.appendChild(document.createTextNode("Bulunan kayıt sayısı: " + data.length));
                    membershipList.appendChild(membershipCount);


                }
                else {
                    // Kullanıcının üyesi olduğu grup bulunamazsa, uyarı mesajı yazdırılıyor.
                    var paragraph = document.createElement("p");
                    paragraph.appendChild(document.createTextNode(warning));
                    membershipList.appendChild(paragraph);
                }
            },
            error: function () {
                var warning = document.createElement("p");
                warning.appendChild(document.createTextNode("Arama yapılırken bir hata oluştu. Lütfen tekrar deneyiniz."));
                membershipList.appendChild(warning);
                $('#loadingGroups').hide();
            },
            complete: function () {
                // "Loading" gif'i ekrandan kaldırılıyor.
                $('#loadingGroups').hide();
            }
        });
    }

    // Türkçe karakterleri, İngilizce karakterlere çeviren metod
    $.toEnglish = function (searchText) {
        searchText = searchText.replace('ç', 'c');
        searchText = searchText.replace('ğ', 'g');
        searchText = searchText.replace('ı', 'i');
        searchText = searchText.replace('ö', 'o');
        searchText = searchText.replace('ş', 's');
        searchText = searchText.replace('ü', 'u');

        return searchText;
    }

});

// Mail ve Security gruplarını göster/gizle (Checkbox'lar için)
function toggle(className, obj) {
    var $input = $(obj);
    if ($input.prop('checked')) $(className).show();
    else $(className).hide();
}