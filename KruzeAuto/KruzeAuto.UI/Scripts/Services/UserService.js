var UserService = function () {
    var _users = [
        {
            UserID: '561FC9B6-74AB-D604-337F-3D83F8504E01',
            Email: 'neagucristianstefan@yahoo.com',
            UserName: 'neagucristianstefan',
            Password: 'UMT365',
            PhoneNumber: '0765537186',
            CreationDate: '2017-12-01 21:33',
            Subscribed: '1'
        },
        {
            UserID: 'E5C24E7A-A819-1E62-E37C-0700402A1B8C',
            Email: 'felis.ullamcorper.viverra@Suspendissenonleo.edu',
            UserName: 'felis',
            Password: 'vivera123',
            PhoneNumber: '0762561832',
            CreationDate: '1996-07-13 12:13',
            Subscribed: ''
        }
        {
            UserID: 'E5C2497A-A819-1E62-E37C-0700402A1B8C',
            Email: 'umt@365.com',
            UserName: 'umt-cluj',
            Password: 'umt365',
            PhoneNumber: '0762561832',
            CreationDate: '1996-07-13 12:13',
            Subscribed: '',
            Country: 'Romania',
            County: 'Cluj',
            City: 'Cluj-Napoca',
            Photo: 'http://beta.umtsoftware.com/wp-content/themes/umt_software/img/umtswlogo500x500.png'
        }
    ];

    this.ReadAll = function () {
        return _users;
    }

    this.ReadById = function (id) {
        for (var index = 0; index < _users.length; index++) {
            if (index == _users[index].AnnoucementID) {
                return _users[index];
            }
        }
        return null;
    } 
};