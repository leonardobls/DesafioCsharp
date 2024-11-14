using DesafioConstrutor.Classes;

class Program
{

    static void Main(string[] args)
    {
        VipCustomer customer1 = new VipCustomer();
        VipCustomer customer2 = new VipCustomer("Leonardo", 5000);
        VipCustomer customer3 = new VipCustomer("Leonardo Bitencourt", 6000, "leonardo.lima@keyworks.com");

    }
}