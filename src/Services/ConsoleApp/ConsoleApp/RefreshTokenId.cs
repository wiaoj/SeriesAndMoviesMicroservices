namespace ConsoleApp {
    public class RefreshTokenId : ValueObject {
        public Guid Value { get; private set; }
        private RefreshTokenId(Guid value) {
            Value = value;
        }

        public static RefreshTokenId GenerateUnique => new(Guid.NewGuid());


        public override IEnumerable<Object> GetEqualityComponents() {
            yield return Value;
        }

        //public static implicit operator RefreshTokenId(Guid id) => new(id);
    }

    public class Name : ValueObject {
        public String FirstName { get; private set; }
        public String LastName { get; private set; }

        private Name(String firstName, String lastName) {
            FirstName= firstName;
            LastName= lastName;
        }

        public static Name CreateInstance(String firstName, String lastName) => new(firstName, lastName);

        public override IEnumerable<Object> GetEqualityComponents() {
            yield return FirstName;
            yield return LastName;
        }
    }
}