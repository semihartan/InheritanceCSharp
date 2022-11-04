using System; 

namespace InheritanceCSharp
{
    class Program
    {
        private enum Sex
        {
            Female,
            Male
        }
        class Person
        {
            private string _name;
            private string _surname;
            private byte _age;
            public Sex _sex;

            public Person(string name, string surname, byte age, Sex sex)
            {
                _name = name;
                _surname = surname;
                _age = age;
                _sex = sex;
            }

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        return;
                    _name = value;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        return;
                    _surname = value;
                }
            }
            public byte Age
            {
                get => _age;
                set
                {
                    if (value < 0)
                        value = 0;
                    if (value > 150)
                        value = 150;
                    _age = value;
                }
            }

            public virtual void DoWork()
            {
                Console.WriteLine("I have no work :(");
            }
            public virtual void Inform()
            {
                Console.WriteLine("Hey, my name is {0} and surname is {1}, I am {2} years old.", _name, _surname, _age);
            }
        }
        class Programmer : Person
        {
            public Programmer(string name, string surname, byte age, Sex sex) : base(name, surname, age, sex)
            {
            }
            public override void DoWork()
            {
                Console.WriteLine("Writing code.");
            }
            public override void Inform()
            {
                base.Inform();
                Console.WriteLine("I am also a Programmer.");
            }
        }
        class Manager : Person
        {
            public Manager(string name, string surname, byte age, Sex sex) : base(name, surname, age, sex)
            {
            }
            public override void DoWork()
            {
                Console.WriteLine("Managing a Company.");
            }
            public new void Inform()
            {
                base.Inform();
                Console.WriteLine("I am also a Manager.");
            }
        }
        static void Main(string[] args)
        { 
            Person person = new Person("Semih", "Artan", 24, Sex.Male);
            person.Inform();
            person.DoWork();

            Programmer programmer = new Programmer("Semih", "Artan", 24, Sex.Male);
            programmer.Inform();
            programmer.DoWork();

            Manager manager = new Manager("Semih", "Artan", 24, Sex.Male);
            manager.Inform();
            manager.DoWork();

            person = programmer;
            person.Inform();
            person.DoWork();

            // When you define a "new" method with the same name as the base method.
            // You define a new method which is independent of the base method. This breaks out 
            // the inheritance hierarchy and when you try to call the "overriden" method 
            // through a pointer of the base type to the derived class. You cannot call
            // your "overriden" method you define with "new" keyword, instead you call
            // the base definition. You can see that obviously in the following example.
            person = manager;
            person.Inform();
            person.DoWork();
        }
    }
}
