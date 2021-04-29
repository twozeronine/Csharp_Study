using System;

abstract class Product
{
  private static int serial = 0;

  // 프로퍼티 호출시 마다 serial 출력한 뒤에 ++
  public string SerialID { get { return String.Format("{0:d5}", serial++); } }

  abstract public DateTime ProductDate { get; set; }
}

class MyProduct : Product
{
  public override DateTime ProductDate { get; set; }
}

class MainApp
{
  static void Main(string[] args)
  {
    Product product_1 = new MyProduct() { ProductDate = new DateTime(2021, 4, 29) };
    Console.WriteLine("Product:{0}, Product Date :{1}", product_1.SerialID, product_1.ProductDate);
    Product product_2 = new MyProduct() { ProductDate = new DateTime(2021, 3, 7) };
    Console.WriteLine("Product:{0}, Product Date :{1}", product_2.SerialID, product_2.ProductDate);
  }
}

/*실행 결과
  Product:00000, Product Date :2021-04-29 오전 12:00:00
  Product:00001, Product Date :2021-03-07 오전 12:00:00
*/