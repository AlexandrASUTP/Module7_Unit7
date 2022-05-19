using System;

namespace Module7_Unit7
{
    abstract class Delivery
    {
        public string Address;
        public Delivery(string address)   // конструктор с параметром
        {
            Address = address;
        }
        public void DisplayAddress() 
        {
            Console.WriteLine(Address);
        }
    }
    class HomeDelivery : Delivery
    {
        public HomeDelivery(string address):base(address)
        {
            
        }
    }
    class PickPointDelivery : Delivery
   {
        public PickPointDelivery(string address) : base(address)
        {

        }
    }
    class ShopDelivery : Delivery
    {
        public ShopDelivery(string address) : base(address)
        {

        }

    }
    class Product
    {
        public string NameProduct; 

        public Product(string nameProduct)      
        {
            NameProduct = nameProduct;
        }

        public virtual void InputProduct()
        {
            Console.WriteLine("Введите то что хотите преобрести:");
            NameProduct = Console.ReadLine();
        }
    }
    class HiTech : Product
    {
        public string Type;
        public HiTech(string nameProduct, string type) : base(nameProduct)   // конструктор с параметрами
        {
         Type = type;
        }
    }
    class Accesories : Product
    {
        public string Type;
        public Accesories(string nameProduct, string type) : base(nameProduct)
        {
            Type = type;
        }
    }
    class CheckDelivery
    {
        public bool CheckDelivery1;
        public bool CheckDelivery2;
        public bool CheckDelivery3;
        public bool CheckDelivery4;
        public void InputDelivery()
        {
            string checkDelivery;
            Console.WriteLine("Введите способ доставки из (На дом, В пункт выдачи, Заберу из магазина):");
            checkDelivery = Console.ReadLine();
            if (checkDelivery == "На дом")
            {
                CheckDelivery1 = true;
            }
            else
            {
                if (checkDelivery == "В пункт выдачи")
                {
                    CheckDelivery2 = true;
                }
                else 
                {
                    if (checkDelivery == "Заберу из магазина")
                    {
                        CheckDelivery3 = true;
                    }
                    else
                    {
                        CheckDelivery4 = true;
                    }
                }
            }
        }


    }
    class PersonData
    {
        public string Address;
        public string Surename;
        public string TelNumber;
        public DateTime DeliveryData;

        private string name = "Неопределено";

        public string Name              // свойство класса
        {
            get { return name; }
            set { name = value; }
        }


        public string DisplayInPutDataPerson(bool CheckDelivery1, bool CheckDelivery2)
        {
            if ((CheckDelivery1 == true)|| (CheckDelivery2 == true))
            {
                Console.WriteLine("Введите свой адрес:");
                Address = Console.ReadLine();
                Console.WriteLine("Введите дату выдачи заказа в формате (гггг.м.д):");
                DeliveryData = DateTime.Parse(Console.ReadLine());
            }
            else
            {
                Address =null;
                DeliveryData = DateTime.MinValue;
            }
            Console.WriteLine("Введите вашу фамилию:");
            Surename = Console.ReadLine();
            Console.WriteLine("Введите ваше имя:");
            name = Console.ReadLine();
            Console.WriteLine("Ваша номер телефона:");
            TelNumber = Console.ReadLine();
            return Address;
        }

    }
    class OutputOrder
    {
        public void OutputOrder1(string Name, string Surename, string ProductName, string HomeAdress, string PickPointAdress, string ShopAdress,
            bool CheckDelivery1, bool CheckDelivery2, bool CheckDelivery3, DateTime Date)
        { 
            Console.WriteLine("//-----------------------");
            Console.WriteLine("---Заказ---");
            Console.WriteLine("Вы {0} {1}", Name, Surename);
            Console.WriteLine("заказали {0}", ProductName);
            if (CheckDelivery1 == true)
            { Console.WriteLine("Заказ приедет к Вам, по адресу: {0}, дата прибытия:{1}", HomeAdress, Date); }
            else 
            {
                if (CheckDelivery2 == true)
                { Console.WriteLine("Вам необходимо забрать заказ из пункта выдачи, по адресу: {0}, дата бронирования:{1}", PickPointAdress); }
                else
                {
                    if (CheckDelivery3 == true)
                    { Console.WriteLine("Вам необходимо забрать заказ из магазина, по адресу: {0}", ShopAdress); }
                }
            }
        }
    }
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;
        //-------------
        HiTech product = new HiTech("Computer","HiTech");
        CheckDelivery checkdelivery = new CheckDelivery();
        PersonData person = new PersonData();
        Delivery pickPointDelivery = new PickPointDelivery("Проспект Передовиков, дом 54");
        Delivery shopDelivery = new ShopDelivery("Проспект Наставников, дом 18");
        OutputOrder outputOrder = new OutputOrder();    

        public void Order1()
        {
            bool CheckItem;
            bool CheckDelivery;
            //---------------------
            product.InputProduct();
            if (product.NameProduct.Length > 0) { CheckItem = true; }
            else 
            { CheckItem = false; 
              Console.WriteLine("До следующих покупок!!!");
            }
            checkdelivery.InputDelivery();
            if ((checkdelivery.CheckDelivery4 != true)&&(CheckItem == true)) { CheckDelivery = true; }
            else 
            { 
                CheckDelivery = false;
                Console.WriteLine("До следующих покупок!!!");
            }
            //---------------------
            person.DisplayInPutDataPerson(checkdelivery.CheckDelivery1, checkdelivery.CheckDelivery2);
            HomeDelivery homeDelivery = new HomeDelivery(person.Address);
            outputOrder.OutputOrder1(person.Name, person.Surename, product.NameProduct, person.Address, pickPointDelivery.Address, shopDelivery.Address,
            checkdelivery.CheckDelivery1, checkdelivery.CheckDelivery2, checkdelivery.CheckDelivery3, person.DeliveryData);

        }
    }     //класс с обобщенным параметром
    class Program
    {
        static void Main(string[] args)
        {
            Order<Delivery> order = new Order<Delivery>();
            order.Order1();
           

            Console.ReadKey();
        }
    }
}
