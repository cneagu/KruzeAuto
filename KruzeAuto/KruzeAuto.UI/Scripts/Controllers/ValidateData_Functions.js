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

function validateUsername(username) {
    if (!(/^[a-z][a-z0-9_.-]{4,19}$/i.test(username))) {
        $('#new-username').addClass("is-invalid");
        username = '';
        return username;
    }
    else {
        $('#new-username').removeClass("is-invalid");
        $('#new-username').addClass("is-valid");
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

function validaterePassword(rePassword, password) {
    if (rePassword != password || rePassword == ''){
        $('#new-c-password').addClass("is-invalid");
        rePassword = '';
        return rePassword;
    } else {
        $('#new-c-password').removeClass("is-invalid");
        $('#new-c-password').addClass("is-valid");
        return rePassword;
    }  
}

function validatePhoneNumber(phoneNumber) {
    if (!(/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/i.test(phoneNumber))) {
        $('#new-phonenumber').addClass("is-invalid");
        phoneNumber = '';
        return phoneNumber;
    } else {
        $('#new-phonenumber').removeClass("is-invalid");
        $('#new-phonenumber').addClass("is-valid");
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

function validate(inputData){
    if ((inputData.username == '' || inputData.username == null) ||
        (inputData.email == '' || inputData.email == null) ||
        (inputData.password == '' || inputData.password == null) ||
        (inputData.rePassword == '' || inputData.rePassword == null) ||
        (inputData.phoneNumber == '' || inputData.phoneNumber == null) ||
        inputData.terms == 0 || inputData.location == 0)
        return 0;
    return 1;
}