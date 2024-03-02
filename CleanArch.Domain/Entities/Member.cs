using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Member : Entity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Gender { get; private set; }
        public string? Email { get; private set; }
        public bool? IsActive { get; private set; }

        public Member(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            ValidateDomain( firstName,  lastName, gender,  email,  isActive);
        }

        public Member(int id, string firstName, string lastName, string gender, string email, bool? isActive)
        {
            DomainValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        public void Update(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }      

        private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            DomainValidation.When(string.IsNullOrEmpty(firstName), "Invalid name. First is required");
            DomainValidation.When(firstName.Length < 3, "Invalid name, too short, minimo 3 characters");
            DomainValidation.When(string.IsNullOrEmpty(lastName), "Invalid LastName. LastName is required");
            DomainValidation.When(lastName.Length < 3, "Invalid LastaName, too short, minimo 3 characters");
            DomainValidation.When(email?.Length < 250, "Invalid email, too long, maximum 250 characters");
            DomainValidation.When(email?.Length < 6, "Invalid email, too short, minimum 6 characters");
            DomainValidation.When(string.IsNullOrEmpty(Gender), "Invalid gender, Gender is required");
            DomainValidation.When(!IsActive.HasValue, "Must define activity");

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }
    }
}
