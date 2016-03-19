using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace dostavka
{
    namespace Functionality
    {
        public class Order
        {
            public int PK_Order;
            public DateTime DateTime;
            public float Sum;
            public float Part;
            public float DriverMoney;
            public int Status; // 0 - ожидание, 1 - выполнение, 2 - отменен, 3 - завершен
            public String Comment;
            //public Destination Destination;
            public String Address;
            public int Countryside;

            public List<OrderLine> Lines;

            public int PK_Driver;
            public int PK_Client;


            public Order()
            {
                PK_Order = -1;
                DateTime = DateTime.Now;
                Sum = 0;
                Part = 0;
                DriverMoney = 0;
                Status = 0;
                Comment = "";
                Lines = new List<OrderLine>();
                // Destination = new Destination();
                Address = "";
                Countryside = 0;
                PK_Driver = -1;
                PK_Client = -1;
            }
            public static Order FromPK(OracleConnection conn, int PK, bool GetLines)
            {
                String cmdQuery = "select \"PK_Order\", \"DateTime\", \"Sum\", \"Part\", \"DriverMoney\", \"Comment\", \"PK_Driver\", \"PK_Client\", \"PK_OrderStatus\", \"Address\", \"Countryside\" from \"Order\" where \"PK_Order\" = " + PK;

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Order TheOrder = new Order();
                    TheOrder.PK_Order = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheOrder.DateTime = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2)) TheOrder.Sum = reader.GetFloat(2);
                    if (!reader.IsDBNull(3)) TheOrder.Part = reader.GetFloat(3);
                    if (!reader.IsDBNull(4)) TheOrder.DriverMoney = reader.GetFloat(4);
                    if (!reader.IsDBNull(5)) TheOrder.Comment = reader.GetString(5);

                    if (!reader.IsDBNull(6)) TheOrder.PK_Driver = reader.GetInt32(6);
                    if (!reader.IsDBNull(7)) TheOrder.PK_Client = reader.GetInt32(7);

                    if (!reader.IsDBNull(8)) TheOrder.Status = reader.GetInt32(8);

                    if (!reader.IsDBNull(9)) TheOrder.Address = reader.GetString(9);
                    if (!reader.IsDBNull(10)) TheOrder.Countryside = reader.GetInt32(10);


                    if (GetLines)
                    {
                        String cmdQuery1 = "select \"PK_OrderLine\" from \"OrderLine\" where \"PK_Order\" = " + TheOrder.PK_Order;
                        OracleCommand cmd1 = new OracleCommand(cmdQuery1);
                        cmd1.Connection = conn;
                        cmd1.CommandType = CommandType.Text;
                        OracleDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            int PK_OrderLine = reader1.GetInt32(0);
                            OrderLine OL = OrderLine.FromPK(conn, PK_OrderLine);
                            OL.Order = TheOrder;
                            TheOrder.Lines.Add(OL);
                        }
                    }

                    return TheOrder;
                }
                return null;
            }

            public bool LinesChangeAllowed()
            {
                if (Status == 0) return true;
                return false;
            }
            public bool CafeChangeAllowed()
            {
                if (Status == 0) return true;
                return false;
            }
            public bool AddressChangeAllowed()
            {
                if (Status == 0 || Status == 1) return true;
                return false;
            }
            public bool DateTimeChangeAllowed()
            {
                if (Status == 0) return true;
                return false;
            }
            public bool DriverChangeAllowed()
            {
                if (Status == 0) return true;
                return false;
            }
            public bool ClientChangeAllowed() {
                if (Status == 0) return true;
                return false;
            }
            public bool DriverMoneyChangeAllowed()
            {
                if (Status == 2) return false;
                if (Status == 3) return false;
                return true;
            }
        }
        public class OrderLine
        {
            public int PK_OrderLine;
            public float Amount;
            public float Cost;
            //public Dish Dish;
            public int PK_Dish;
            public Order Order;

            public OrderLine()
            {
                PK_OrderLine = -1;
                Amount = 0;
                Cost = 0;
                PK_Dish = -1;
                Order = null;
            }

            public static OrderLine FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery1 = "select \"PK_OrderLine\",\"Amount\", \"Cost\", \"PK_Dish\" " +
                            "from \"OrderLine\" where \"PK_OrderLine\" = " + PK;
                OracleCommand cmd1 = new OracleCommand(cmdQuery1);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.Text;
                OracleDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    OrderLine TheLine = new OrderLine();
                    TheLine.PK_OrderLine = reader1.GetInt32(0);
                    if (!reader1.IsDBNull(1)) TheLine.Amount = reader1.GetFloat(1);
                    if (!reader1.IsDBNull(2)) TheLine.Cost = reader1.GetFloat(2);
                    if (!reader1.IsDBNull(3)) TheLine.PK_Dish = reader1.GetInt32(3);

                    return TheLine;
                }
                return null;
            }
        }
        public class OrdersController
        {
            public static List<Order> GetOrdersList(OracleConnection conn, bool GetLines)
            {
                return GetOrdersList(conn,GetLines,-1);
            }
            public static List<Order> GetOrdersList(OracleConnection conn, bool GetLines, int Status)
            {
                String cmdQuery = "select \"PK_Order\", \"DateTime\", \"Sum\", \"Part\", \"Comment\", \"PK_Driver\", \"PK_Client\", \"PK_OrderStatus\" from \"Order\"";
                if (Status >= 0) cmdQuery += " where \"PK_OrderStatus\" = "+Status;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Order> Orders = new List<Order>();

                while (reader.Read())
                {
                    int PK_Order = reader.GetInt32(0);
                    Order TheOrder = Order.FromPK(conn, PK_Order, true);
                    Orders.Add(Order.FromPK(conn, PK_Order, true));
                }
                return Orders;
            }
            public static void AddOrder(OracleConnection conn, Order TheOrder)
            {
                String SEQ_Query = "select SEQ.NEXTVAL from dual";
                OracleCommand SEQcmd = new OracleCommand(SEQ_Query);
                SEQcmd.Connection = conn;
                SEQcmd.CommandType = CommandType.Text;
                OracleDataReader SEQreader = SEQcmd.ExecuteReader();
                SEQreader.Read();
                int PK = SEQreader.GetInt32(0);
                TheOrder.PK_Order = PK;

                String cmdQuery = "insert into \"Order\" (\"PK_Order\", \"PK_OrderStatus\", \"DateTime\", \"Sum\", \"Part\", \"PK_Driver\", \"PK_Client\", \"Address\", \"Countryside\", \"Comment\", \"PK_Dispatcher\")"
                         + " values ("+ PK +","
                         + TheOrder.Status + ","
                         + "to_date('" + (TheOrder.DateTime.ToString("dd-MM-yyyy HH:mm")) + "', 'dd-mm-yyyy hh24:mi'),"
                         + "'" + TheOrder.Sum + "',"
                         + "'" + TheOrder.Part + "',";
                if (TheOrder.PK_Driver > 0) cmdQuery += TheOrder.PK_Driver + ",";
                else cmdQuery += "null,";
                if (TheOrder.PK_Client > 0) cmdQuery += TheOrder.PK_Client + ",";
                else cmdQuery += "null,";
                cmdQuery += "'" + (TheOrder.Address.Replace("'", "\\'")) + "',"
                         + TheOrder.Countryside + ","
                         + "'" + (TheOrder.Comment.Replace("'", "\\'")) + "'";
                cmdQuery += ",null";
                cmdQuery += ")";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                if (true)
                {
                    for (int i = 0; i < TheOrder.Lines.Count; i++)
                    {
                        AddOrderLine(conn, TheOrder, TheOrder.Lines[i]);
                    }
                }
            }
            public static void UpdateOrder(OracleConnection conn, Order TheOrder, bool UpdateLines)
            {
                String cmdQuery = "update \"Order\" set ";
                cmdQuery += "\"PK_OrderStatus\" = " + TheOrder.Status + ",";
                if (TheOrder.DateTimeChangeAllowed()) cmdQuery += "\"DateTime\" = to_date('" + (TheOrder.DateTime.ToString("dd-MM-yyyy HH:mm")) + "', 'dd-mm-yyyy hh24:mi'),";
                cmdQuery += "\"Sum\" = '" + TheOrder.Sum + "',";
                cmdQuery += "\"Part\" = '" + TheOrder.Part + "',";
                if (TheOrder.DriverChangeAllowed())
                {
                    if (TheOrder.PK_Driver > 0) cmdQuery += "\"PK_Driver\" = " + TheOrder.PK_Driver + ",";
                    else cmdQuery += "\"PK_Driver\" = null,";
                }
                if (TheOrder.PK_Client > 0) cmdQuery += "\"PK_Client\" = " + TheOrder.PK_Client + ",";
                else cmdQuery += "\"PK_Client\" = null,";
                if (TheOrder.AddressChangeAllowed())
                {
                    cmdQuery += "\"Address\" = '" + (TheOrder.Address.Replace("'", "\\'")) + "',";
                    cmdQuery += "\"Countryside\" = " + TheOrder.Countryside + ",";
                }
                cmdQuery += "\"Comment\" = '" + (TheOrder.Comment.Replace("'", "\\'")) + "' "
                         + "where \"PK_Order\" = " + TheOrder.PK_Order;

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                if (UpdateLines && TheOrder.LinesChangeAllowed())
                {
                    DeleteOrderLines(conn, TheOrder);
                    for (int i = 0; i < TheOrder.Lines.Count; i++)
                    {
                        AddOrderLine(conn, TheOrder, TheOrder.Lines[i]);
                    }
                }
            }
            public static void AddOrderLine(OracleConnection conn, Order TheOrder, OrderLine TheLine)
            {
                if (!TheOrder.LinesChangeAllowed()) return;
                String cmdQuery = "insert into \"OrderLine\" (\"PK_OrderLine\", \"PK_Order\", \"Amount\", \"Cost\", \"PK_Dish\")"
                         + " values (null,"
                         + "'" + TheOrder.PK_Order + "',"
                         + "'" + TheLine.Amount + "',"
                         + "'" + TheLine.Cost + "'";
                if (TheLine.PK_Dish > 0) cmdQuery += "," + TheLine.PK_Dish;
                else cmdQuery += ",null";
                cmdQuery += ")";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void DeleteOrderLine(OracleConnection conn, OrderLine TheLine)
            {
                if (TheLine.Order != null && !TheLine.Order.LinesChangeAllowed()) return;
                String cmdQuery = "delete from \"OrderLine\" where \"PK_OrderLine\" = " + TheLine.PK_OrderLine;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void DeleteOrderLines(OracleConnection conn, Order TheOrder)
            {
                if (!TheOrder.LinesChangeAllowed()) return;
                String cmdQuery = "delete from \"OrderLine\" where \"PK_Order\" = " + TheOrder.PK_Order;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            public static float CountCost(OracleConnection conn, OrderLine TheLine)
            {
                return TheLine.Amount * Dish.FromPK(conn, TheLine.PK_Dish).Price;
            }
            public static float CountSum(Order TheOrder, float CityTariff, float CountryTariff)
            {
                float Sum = 0;
                for (int i = 0; i < TheOrder.Lines.Count; i++)
                {
                    Sum += TheOrder.Lines[i].Cost;
                }
                if (TheOrder.Countryside != 0) Sum += CountryTariff;
                else Sum += CityTariff;

                return Sum;
            }
            public static float CountPart(float Sum, float Part)
            {
                return Sum * Part;
            }
        }
        public class Dish
        {
            public int PK_Dish;
            public String Name;
            public String Description;
            public float Price;
            public int PK_Cafe;
            public bool Disabled;

            public Dish()
            {
                PK_Dish = -1;
                Name = "";
                Price = 0;
                PK_Cafe = -1;
                Disabled = false;
            }
            public static Dish FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery1 = "select \"PK_Dish\", \"Name\", \"Price\", \"PK_Cafe\", \"Disabled\", \"Description\" from \"Dish\" where \"PK_Dish\" = " + PK;

                OracleCommand cmd1 = new OracleCommand(cmdQuery1);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.Text;
                OracleDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    Dish TheDish = new Dish();
                    TheDish.PK_Dish = reader1.GetInt32(0);
                    if (!reader1.IsDBNull(1)) TheDish.Name = reader1.GetString(1);
                    if (!reader1.IsDBNull(2)) TheDish.Price = reader1.GetFloat(2);
                    if (!reader1.IsDBNull(3)) TheDish.PK_Cafe = reader1.GetInt32(3);
                    if (!reader1.IsDBNull(4)) TheDish.Disabled = (reader1.GetInt32(4) != 0);
                    if (!reader1.IsDBNull(5)) TheDish.Description = reader1.GetString(5);

                    return TheDish;
                }
                return null;
            }
            public static Dish FromName(OracleConnection conn, String Name, int PK_Cafe) {
                String cmdQuery1 = "select \"PK_Dish\", \"Name\", \"Price\", \"PK_Cafe\", \"Disabled\", \"Description\" from \"Dish\" where \"Name\" = '" + Name.Replace("'","\\'") +"'";
                if (PK_Cafe > 0) cmdQuery1 += " and \"PK_Cafe\" = "+PK_Cafe;

                OracleCommand cmd1 = new OracleCommand(cmdQuery1);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.Text;
                OracleDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    Dish TheDish = new Dish();
                    TheDish.PK_Dish = reader1.GetInt32(0);
                    if (!reader1.IsDBNull(1)) TheDish.Name = reader1.GetString(1);
                    if (!reader1.IsDBNull(2)) TheDish.Price = reader1.GetFloat(2);
                    if (!reader1.IsDBNull(3)) TheDish.PK_Cafe = reader1.GetInt32(3);
                    if (!reader1.IsDBNull(4)) TheDish.Disabled = (reader1.GetInt32(4) != 0);
                    if (!reader1.IsDBNull(5)) TheDish.Description = reader1.GetString(5);

                    return TheDish;
                }
                return null;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        public class DishController
        {
            public static List<Dish> GetDishList(OracleConnection conn, bool IncludeDisabled)
            {
                String cmdQuery = "select \"PK_Dish\" from \"Dish\"";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Dish> Dishes = new List<Dish>();

                while (reader.Read())
                {
                    int PK_Dish = reader.GetInt32(0);
                    Dish TheDish = Dish.FromPK(conn, PK_Dish);
                    if (!TheDish.Disabled || IncludeDisabled) Dishes.Add(TheDish);
                }
                return Dishes;
            }
            public static List<Dish> GetDishList(OracleConnection conn, int PK_Cafe, bool IncludeDisabled)
            {
                String cmdQuery = "select \"PK_Dish\" from \"Dish\" where \"PK_Cafe\" = "+PK_Cafe;

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Dish> Dishes = new List<Dish>();

                while (reader.Read())
                {
                    int PK_Dish = reader.GetInt32(0);
                    Dish TheDish = Dish.FromPK(conn, PK_Dish);
                    if (!TheDish.Disabled || IncludeDisabled) Dishes.Add(TheDish);
                }
                return Dishes;
            }

            public static bool DishInUse(OracleConnection conn, int PK_Dish) {
                String cmdQuery = "select \"Order\".\"PK_Order\" from \"Order\", \"OrderLine\""+
                    " where \"Order\".\"PK_Order\" = \"OrderLine\".\"PK_Order\" and \"Order\".\"PK_OrderStatus\" = 0 and \"OrderLine\".\"PK_Dish\" = " + PK_Dish;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) return true;

                return false;
            }

            public static void AddDish(OracleConnection conn, Dish TheDish)
            {
                String SEQ_Query = "select SEQ.NEXTVAL from dual";
                OracleCommand SEQcmd = new OracleCommand(SEQ_Query);
                SEQcmd.Connection = conn;
                SEQcmd.CommandType = CommandType.Text;
                OracleDataReader SEQreader = SEQcmd.ExecuteReader();
                SEQreader.Read();
                int PK = SEQreader.GetInt32(0);

                TheDish.PK_Dish = PK;

                String cmdQuery = "insert into \"Dish\" (\"PK_Dish\", \"Name\", \"Price\", \"PK_Cafe\",\"Disabled\")"
                        + " values (" + PK + ",'"
                        + (TheDish.Name.Replace("'", "\\'")) + "','"
                        + (TheDish.Price.ToString()) + "','"
                        + (TheDish.PK_Cafe) + "',"
                        + "0)";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateDish(OracleConnection conn, Dish TheDish)
            {
                String cmdQuery = "update \"Dish\" set " +
                    "\"Name\" = '" + (TheDish.Name.Replace("'", "\\'")) + "'," +
                    "\"Price\" = '" + (TheDish.Price.ToString()) + "',";
                if (TheDish.Disabled) cmdQuery += "\"Disabled\" = 1,";
                else cmdQuery += "\"Disabled\" = 0,";
                if (TheDish.PK_Cafe > 0) cmdQuery += "\"PK_Cafe\" = '" + (TheDish.PK_Cafe) + "'";
                else cmdQuery += "\"PK_Cafe\" = null";
                cmdQuery += " where \"PK_Dish\" = " + TheDish.PK_Dish;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void DisableDish(OracleConnection conn, Dish TheDish)
            {
                DisableDish(conn, TheDish.PK_Dish);
            }
            public static void DisableDish(OracleConnection conn, int PK_Dish)
            {
                if (DishInUse(conn, PK_Dish)) return;
                String cmdQuery = "update \"Dish\" set \"Disabled\" = 1 where \"PK_Dish\" = " + PK_Dish;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void EnableDish(OracleConnection conn, Dish TheDish)
            {
                EnableDish(conn, TheDish.PK_Dish);
            }
            public static void EnableDish(OracleConnection conn, int PK_Dish)
            {
                String cmdQuery = "update \"Dish\" set \"Disabled\" = 0 where \"PK_Dish\" = " + PK_Dish;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public class Driver
        {
            public int PK_Driver;
            public String Name;
            public String Phone;
            public Driver()
            {
                PK_Driver = -1;
                Name = "";
                Phone = "";
            }

            public static Driver FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery1 = "select \"PK_Driver\", \"Name\", \"Phone\" from \"Driver\" where \"PK_Driver\" = " + PK;

                OracleCommand cmd1 = new OracleCommand(cmdQuery1);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.Text;
                OracleDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    Driver TheDriver = new Driver();
                    TheDriver.PK_Driver = reader1.GetInt32(0);
                    if (!reader1.IsDBNull(1)) TheDriver.Name = reader1.GetString(1);
                    if (!reader1.IsDBNull(2)) TheDriver.Phone = reader1.GetString(2);

                    return TheDriver;
                }
                return null;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        public class DriverController
        {
            public static List<Driver> GetDriversList(OracleConnection conn)
            {
                String cmdQuery = "select \"PK_Driver\", \"Name\", \"Phone\" from \"Driver\"";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Driver> Drivers = new List<Driver>();

                while (reader.Read())
                {
                    Driver TheDriver = new Driver();
                    TheDriver.PK_Driver = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheDriver.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) TheDriver.Phone = reader.GetString(2);
                    Drivers.Add(TheDriver);
                }
                return Drivers;
            }
            public static void AddDriver(OracleConnection conn, Driver TheDriver)
            {
                String SEQ_Query = "select SEQ.NEXTVAL from dual";
                OracleCommand SEQcmd = new OracleCommand(SEQ_Query);
                SEQcmd.Connection = conn;
                SEQcmd.CommandType = CommandType.Text;
                OracleDataReader SEQreader = SEQcmd.ExecuteReader();
                SEQreader.Read();
                int PK = SEQreader.GetInt32(0);

                TheDriver.PK_Driver = PK;

                String cmdQuery = "insert into \"Driver\" (\"PK_Driver\", \"Name\", \"Phone\")"
                        + " values (" + PK + ",'"
                        + (TheDriver.Name.Replace("'", "\\'")) + "','"
                        + (TheDriver.Phone.Replace("'", "\\'")) + "')";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateDriver(OracleConnection conn, Driver TheDriver) {
                String cmdQuery = "update \"Driver\" set " +
                        "\"Name\" = '" + (TheDriver.Name.Replace("'", "\\'")) + "'," +
                        "\"Phone\" = '" + (TheDriver.Phone.Replace("'", "\\'")) + "'," +
                        " where \"PK_Driver\" = " + TheDriver.PK_Driver;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public class Client
        {
            public int PK_Client;
            public String Name;
            public String Phone;
            public int Discount;
            public Client()
            {
                PK_Client = -1;
                Name = "";
                Phone = "";
                Discount = 0;
            }

            public static Client FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery1 = "select \"PK_Client\", \"Name\", \"Phone\", \"Discount\" from \"Client\" where \"PK_Client\" = " + PK;

                OracleCommand cmd1 = new OracleCommand(cmdQuery1);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.Text;
                OracleDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    Client TheClient = new Client();
                    TheClient.PK_Client = reader1.GetInt32(0);
                    if (!reader1.IsDBNull(1)) TheClient.Name = reader1.GetString(1);
                    if (!reader1.IsDBNull(2)) TheClient.Phone = reader1.GetString(2);
                    if (!reader1.IsDBNull(3)) TheClient.Discount = reader1.GetInt32(3);

                    return TheClient;
                }
                return null;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        public class ClientController
        {
            public static List<Client> GetClientsList(OracleConnection conn)
            {
                String cmdQuery = "select \"PK_Client\", \"Name\", \"Phone\", \"Discount\" from \"Client\"";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Client> Clients = new List<Client>();

                while (reader.Read())
                {
                    Client TheClient = new Client();
                    TheClient.PK_Client = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheClient.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) TheClient.Phone = reader.GetString(2);
                    if (!reader.IsDBNull(3)) TheClient.Discount = reader.GetInt32(3);
                    Clients.Add(TheClient);
                }
                return Clients;
            }
            public static void AddClient(OracleConnection conn, Client TheClient)
            {
                String SEQ_Query = "select SEQ.NEXTVAL from dual";
                OracleCommand SEQcmd = new OracleCommand(SEQ_Query);
                SEQcmd.Connection = conn;
                SEQcmd.CommandType = CommandType.Text;
                OracleDataReader SEQreader = SEQcmd.ExecuteReader();
                SEQreader.Read();
                int PK = SEQreader.GetInt32(0);

                TheClient.PK_Client = PK;

                String cmdQuery = "insert into \"Client\" (\"PK_Client\", \"Name\", \"Phone\", \"Discount\")"
                        + " values ("+ PK +",'"
                        + (TheClient.Name.Replace("'", "\\'")) + "','"
                        + (TheClient.Phone.Replace("'", "\\'")) + "',"
                        + "'" + TheClient.Discount + "')";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateClient(OracleConnection conn, Client TheClient)
            {
                String cmdQuery = "update \"Client\" set " +
                        "\"Name\" = '" + (TheClient.Name.Replace("'", "\\'")) + "'," +
                        "\"Phone\" = '" + (TheClient.Phone.Replace("'", "\\'")) + "'," +
                        "\"Discount\" = '" + TheClient.Discount + "'" +
                        " where \"PK_Client\" = " + TheClient.PK_Client;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public class Cafe {
            public int PK_Cafe;
            public String Name;
            public String Address;
            public String Phone;
            public Cafe() {
                PK_Cafe = -1;
                Name = "";
                Address = "";
                Phone = "";
            }
            public static Cafe FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery = "select \"PK_Cafe\", \"Name\", \"Address\", \"Phone\" from \"Cafe\" where \"PK_Cafe\" = " + PK;

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Cafe TheCafe = new Cafe();
                    TheCafe.PK_Cafe = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheCafe.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) TheCafe.Address = reader.GetString(2);
                    if (!reader.IsDBNull(3)) TheCafe.Phone = reader.GetString(3);
                    
                    return TheCafe;
                }
                return null;
            }
            public static Cafe FromName(OracleConnection conn, String Name)
            {
                String cmdQuery = "select \"PK_Cafe\", \"Name\", \"Address\", \"Phone\" from \"Cafe\" where \"Name\" = '" + Name.Replace("'","\\'") + "'";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Cafe TheCafe = new Cafe();
                    TheCafe.PK_Cafe = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheCafe.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) TheCafe.Address = reader.GetString(2);
                    if (!reader.IsDBNull(3)) TheCafe.Phone = reader.GetString(3);

                    return TheCafe;
                }
                return null;
            }
        }
        public class CafeController {
            public static List<Cafe> GetCafeList(OracleConnection conn)
            {
                String cmdQuery = "select \"PK_Cafe\" from \"Cafe\"";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Cafe> Cafes = new List<Cafe>();

                while (reader.Read())
                {
                    int PK_Cafe = reader.GetInt32(0);
                    Cafes.Add(Cafe.FromPK(conn, PK_Cafe));
                }
                return Cafes;
            }
            public static void AddCafe(OracleConnection conn, Cafe TheCafe)
            {
                String SEQ_Query = "select SEQ.NEXTVAL from dual";
                OracleCommand SEQcmd = new OracleCommand(SEQ_Query);
                SEQcmd.Connection = conn;
                SEQcmd.CommandType = CommandType.Text;
                OracleDataReader SEQreader = SEQcmd.ExecuteReader();
                SEQreader.Read();
                int PK = SEQreader.GetInt32(0);

                TheCafe.PK_Cafe = PK;

                String cmdQuery = "insert into \"Cafe\" (\"PK_Cafe\", \"Name\", \"Address\", \"Phone\")"
                        + " values (" + PK + ",'"
                        + (TheCafe.Name.Replace("'", "\\'")) + "','"
                        + (TheCafe.Address.Replace("'", "\\'")) + "','"
                        + (TheCafe.Phone.Replace("'", "\\'")) + "')";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateCafe(OracleConnection conn, Cafe TheCafe) {
                String cmdQuery = "update \"Cafe\" set " +
                    "\"Name\" = '" + (TheCafe.Name.Replace("'", "\\'")) + "'," +
                    "\"Address\" = '" + (TheCafe.Address.Replace("'", "\\'")) + "'," +
                    "\"Phone\" = '" + (TheCafe.Phone.Replace("'", "\\'")) + "'" +
                    " where \"PK_Cafe\" = " + TheCafe.PK_Cafe;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateCafeMenu(OracleConnection conn, Cafe TheCafe, List<Dish> Dishes) {
                List<Dish> DishesToUpdate = new List<Dish>();
                List<Dish> DishesToAdd = new List<Dish>();
                DisableDishes(conn, TheCafe);
                for (int i = 0; i < Dishes.Count; i++) {
                    if (Dishes[i].PK_Dish > 0) DishesToUpdate.Add(Dishes[i]);
                    else DishesToAdd.Add(Dishes[i]);
                }
                for (int i = 0; i < DishesToUpdate.Count; i++)
                {
                    DishController.UpdateDish(conn, DishesToUpdate[i]);
                    DishController.EnableDish(conn, DishesToUpdate[i]);
                }
                for (int i = 0; i < DishesToAdd.Count; i++)
                {
                    DishController.UpdateDish(conn, DishesToAdd[i]);
                    DishController.EnableDish(conn, DishesToAdd[i]);
                }
            }
            public static void DisableDishes(OracleConnection conn, Cafe TheCafe) {
                List<Dish> Dishes = DishController.GetDishList(conn, false);
                for (int i = 0; i < Dishes.Count; i++) {
                    DishController.DisableDish(conn, Dishes[i]);
                }
            }
        }
    }
}
