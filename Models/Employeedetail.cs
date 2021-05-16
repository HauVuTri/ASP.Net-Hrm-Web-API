using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    public partial class Employeedetail
    {
        public Guid EmployeeDetailId { get; set; }
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string PersonalTaxCode { get; set; }
        public string Ethnic { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string IdentifyCardNumber { get; set; }
        public DateTime? IdentityCardDate { get; set; }
        public string IdentityCardPlace { get; set; }
        public DateTime? IdentityCardEndDate { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? PassportDate { get; set; }
        public string PassportPlace { get; set; }
        public DateTime? PassportEndDate { get; set; }
        public string EducationalLevel { get; set; }
        public string TrainingLevel { get; set; }
        public string TrainingPlace { get; set; }
        public string SchoolYear { get; set; }
        public string Specialized { get; set; }
        public DateTime? GraduationYear { get; set; }
        public string ClassificationLearn { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string OtherPhone { get; set; }
        public string Email { get; set; }
        public string OfficeEmail { get; set; }
        public string OtherEmail { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string ResidenceNationality { get; set; }
        public string ResidenceCountry { get; set; }
        public string ResidenceProvince { get; set; }
        public string ResidenceDistrict { get; set; }
        public string ResidenceWard { get; set; }
        public string ResidenceStreet { get; set; }
        public string ResidenceFullAddress { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentProvince { get; set; }
        public string CurrentDistrict { get; set; }
        public string CurrentWard { get; set; }
        public string CurrentStreet { get; set; }
        public string CurrentFullAddress { get; set; }
        public string UrgentContactName { get; set; }
        public string UrgentContactPhone { get; set; }
        public string UrgentContactRelationship { get; set; }
        public string UrgentContactEmail { get; set; }
        public string UrgentContactAddress { get; set; }
        public Guid? JobDetailJobPositionId { get; set; }
        public string JobDetailJobPositionName { get; set; }
    }
}
