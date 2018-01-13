var AnnouncementService = function () {
    var _announcements = [
        {
            AnnoucementID: '9E5060AB-E64C-4E3A-DC3F-5C5B627FB6C2',
            UserID: '561FC9B6-74AB-D604-337F-3D83F8504E01',
            VehicleType: 1,
            Views: 20,
            Promoted: 1,
            Active: 1,
            CreationDate: '2017-05-10 07:00',
            Update: '2017-05-10 07:00',
            Condition: 'New',
            Title: 'BMW M4 450HP',
            Brand: 'BMW',
            Model: 'M4',
            Type: 'Coupe',
            Kilometer: 100000,
            FabricationYear: 2014,
            VIN: 'WDDKK7CF6BF088425',
            FuelType: 'Petrol',
            Price: 72000,
            NegociablePrice: 1,
            Currency: 'EUR',
            Color: 'Blue',
            ColorType: 'Metalic',
            Power: 450,
            Transmission: 'Automatic',
            CubicCapacity: 2979,
            EmissionClass: 'Euro6',
            NumberOfSeats: 4,
            GVW: '',
            LoadCapacity: '',
            OperatingHours: '',
            Description: 'Descriere Vehicul de test',
            AnnouncementsOptions: ['bf0c2179-cd26-4dd3-a485-db4c863d3365',
                'f165324b-4ae7-406b-977d-84fa69042ac0',
                'e214d7f3-33ac-4442-9e79-5cf03d854f98',
                '51474804-dc92-48d8-9880-d1a82620d57e',
                'a66e4814-1f72-497b-8e1f-c3446c9144c5'
            ],
            AnnouncementsPicturesPrimary: 'http://cdn.bmwblog.com/wp-content/uploads/2016/06/schnitzer-m4-eas-1-750x500.jpg',
            AnnouncementsPictures: ['http://cdn.bmwblog.com/wp-content/uploads/2016/06/schnitzer-m4-eas-12-750x469.jpg']
        },
        {
            AnnoucementID: '9E5060cB-E64C-4E3A-DC3F-5C5B627FB6C2',
            UserID: '561FC9B6-74AB-D604-337F-3D83F8504E01',
            VehicleType: 1,
            Views: 25,
            Promoted: 0,
            Active: 1,
            CreationDate: '2017-06-21 07:00',
            Update: '2017-05-10 07:00',
            Condition: 'New',
            Title: 'BMW M4 450HP',
            Brand: 'BMW',
            Model: 'M4',
            Type: 'Coupe',
            Kilometer: 130000,
            FabricationYear: 2014,
            VIN: 'WDDKK9CF6B8588425',
            FuelType: 'Petrol',
            Price: 69000,
            NegociablePrice: 1,
            Currency: 'EUR',
            Color: 'Blue',
            ColorType: 'Metalic',
            Power: 450,
            Transmission: 'Automatic',
            CubicCapacity: 2979,
            EmissionClass: 'Euro6',
            NumberOfSeats: 4,
            GVW: '',
            LoadCapacity: '',
            OperatingHours: '',
            Description: 'Descriere Vehicul de test',
            AnnouncementsOptions: ['bf0c2179-cd26-4dd3-a485-db4c863d3365',
                'f165324b-4ae7-406b-977d-84fa69042ac0',
                'e214d7f3-33ac-4442-9e79-5cf03d854f98',
                '51474804-dc92-48d8-9880-d1a82620d57e',
                'a66e4814-1f72-497b-8e1f-c3446c9144c5'
            ],
            AnnouncementsPicturesPrimary: 'http://www.lomawheels.com/wp-content/grand-media/image/loma-wheels-bmw-m4-vorsteiner-3.jpg',
            AnnouncementsPictures: ['http://www.lomawheels.com/wp-content/grand-media/image/loma-wheels-bmw-m4-vorsteiner-5_1.jpg',
                'http://www.lomawheels.com/wp-content/grand-media/image/loma-wheels-bmw-m4-vorsteiner-1.jpg']
        },
        {
            AnnoucementID: '8E5060cB-E64C-4E3A-DC3F-5C5B627FB6C2',
            UserID: '561FC9B6-74AB-D604-337F-3D83F8504E01',
            VehicleType: 1,
            Views: 25,
            Promoted: 0,
            Active: 1,
            CreationDate: '2017-06-21 07:00',
            Update: '2017-05-10 07:00',
            Condition: 'Used',
            Title: 'Mercedes S 63AMG',
            Brand: 'Mercedes',
            Model: 'S Class',
            Type: 'Coupe',
            Kilometer: 3000,
            FabricationYear: 2015,
            VIN: 'WDDKK9CF6B8588425',
            FuelType: 'Petrol',
            Price: 199000,
            NegociablePrice: 1,
            Currency: 'EUR',
            Color: 'Blue',
            ColorType: 'Metalic',
            Power: 450,
            Transmission: 'Automatic',
            CubicCapacity: 2979,
            EmissionClass: 'Euro6',
            NumberOfSeats: 4,
            GVW: '',
            LoadCapacity: '',
            OperatingHours: '',
            Description: 'Descriere Vehicul de test',
            AnnouncementsOptions: ['bf0c2179-cd26-4dd3-a485-db4c863d3365',
                'f165324b-4ae7-406b-977d-84fa69042ac0',
                'e214d7f3-33ac-4442-9e79-5cf03d854f98',
                '51474804-dc92-48d8-9880-d1a82620d57e',
                'a66e4814-1f72-497b-8e1f-c3446c9144c5'
            ],
            AnnouncementsPicturesPrimary: 'http://2.bp.blogspot.com/-F1TTl3mwpdA/VcO4Fb3CLiI/AAAAAAAAS9c/VYaxW7AbU4w/s1600/vossen-merc-s63amg-matte-1.jpg',
            AnnouncementsPictures: ['http://4.bp.blogspot.com/-e2pJpH5MqHM/VcO4JRZrKnI/AAAAAAAAS-Q/_CQUUtMqRiw/s1600/vossen-merc-s63amg-matte-9.jpg',
                'http://4.bp.blogspot.com/-3VeP92tBoxI/VcO4COLQRbI/AAAAAAAAS9Q/QEm8qy9foUc/s1600/vossen-merc-s63amg-matte-12.jpg']
        }
    ];

    this.ReadAll = function () {
        return _announcements;
    }

    this.ReadById = function (id) {
        for (var index = 0; index < _announcements.length; index++) {
            if (index == _announcements[index].AnnoucementID) {
                return _announcements[index];
            }
        }

        return null;
    }
    
}