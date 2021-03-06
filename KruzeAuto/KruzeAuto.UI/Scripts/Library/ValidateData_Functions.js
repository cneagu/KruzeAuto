﻿function validateDigits(val, id) {
    if (!(/^[0-9]+$/i.test(val))) {
        $(id).addClass("is-invalid");
        val = '';
        return val;
    } else {
        $(id).removeClass("is-invalid");
        $(id).addClass("is-valid");
        return val;
    }    
}

function validateEmail(email, id) {
    if (!(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i.test(email))) {
        $(id).addClass("is-invalid");
        email = '';
        return email;
    } else {
        $(id).removeClass("is-invalid");
        $(id).addClass("is-valid");
        return email;
    }       
}

function validateUsername(username, id) {
    if (!(/^[a-z][a-z0-9_.-]{4,19}$/i.test(username))) {
        $(id).addClass("is-invalid");
        username = '';
        return username;
    }
    else {
        $(id).removeClass("is-invalid");
        $(id).addClass("is-valid");
        return username;
    }   
}

function validatePassword(password, id) {
    if (!(/^(?=.*\d)(?=.*[a-z])[0-9a-zA-Z]{6,}$/i.test(password))) {
        $(id).addClass("is-invalid");
        password = '';
        return password;
    } else {
        $(id).removeClass("is-invalid");
        $(id).addClass("is-valid");
        return password;
    }   
}

function validaterePassword(rePassword, password, id) {
    if (rePassword != password || rePassword == ''){
        $(id).addClass("is-invalid");
        rePassword = '';
        return rePassword;
    } else {
        $(id).removeClass("is-invalid");
        $(id).addClass("is-valid");
        return rePassword;
    }  
}

function validatePhoneNumber(phoneNumber, id) {
    if (!(/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/i.test(phoneNumber))) {
        $(id).addClass("is-invalid");
        phoneNumber = '';
        return phoneNumber;
    } else {
        $(id).removeClass("is-invalid");
        $(id).addClass("is-valid");
        return phoneNumber;
    }   
}

function locationValidate(country, county, city) {
    if (country == null || country == '') {
        $('#new-country').addClass("is-invalid");
        $('#new-county').addClass("is-invalid");
        $('#new-city').addClass("is-invalid");
        return 0;
    }
    else if (county == null || county == '') {
        $('#new-country').removeClass("is-invalid");
        $('#new-country').addClass("is-valid");
        $('#new-county').addClass("is-invalid");
        $('#new-city').addClass("is-invalid");
        return 0;
    }
    else if (city == null || city == '') {
        $('#new-country').removeClass("is-invalid");
        $('#new-county').removeClass("is-invalid");
        $('#new-country').addClass("is-valid");
        $('#new-county').addClass("is-valid");
        $('#new-city').addClass("is-invalid");
        return 0;
    } else {
        $('#new-country').removeClass("is-invalid");
        $('#new-county').removeClass("is-invalid");
        $('#new-city').removeClass("is-invalid");
        $('#new-country').addClass("is-valid");
        $('#new-county').addClass("is-valid");
        $('#new-city').addClass("is-valid");
        return 1;
    }       
}

function validateTerms(term) {
    if (term == 0)
        alert("Please read an check Terms and conditions");
    return term;
}

function validate(inputData) {
    for (var i in inputData) {
        if (inputData[i] == '' || inputData[i] == null || inputData[i] == 0) {
            alert(i + '  Is not Ok');
            return 0;
        }         
    }
    return 1;
}

function validateDigit(nb) {
    if (isNaN(nb))
        return 0;
    return nb;
}
function validationText(t) {
    if (t == '' || t == undefined)
        return '';
    else return t;
}

function validateCurentPassword(paswword) {
    if (CURENT_USER.Password == paswword)
        return paswword;
    return '';
}


//function validateVIN(vin, id) {
//    if (!(/^(?:([A-HJ-NPR-Z]){3}|\d{3})(?1){2}\d{2}(?:(?1)|\d)(?:\d|X)(?:(?1)+\d+|\d+(?1)+)\d{6}$/i.test(vin))) {
//        $(id).addClass("is-invalid");
//        vin = '';
//        return password;
//    } else {
//        $(id).removeClass("is-invalid");
//        $(id).addClass("is-valid");
//        return vin;
//    }   
//}