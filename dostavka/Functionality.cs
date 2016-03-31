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
            public DateTime RegDateTime;
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
                String cmdQuery = "select \"PK_Order\", \"DateTime\", \"Sum\", \"Part\", \"DriverMoney\", \"Comment\", \"PK_Driver\", \"PK_Client\", \"PK_OrderStatus\", \"Address\", \"Countryside\", \"RegDateTime\" from \"Order\" where \"PK_Order\" = " + PK;

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
                    if (!reader.IsDBNull(11)) TheOrder.RegDateTime = reader.GetDateTime(11);


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
<<<<<<< HEAD
                if (Status < 2) return true;
=======
                if (Status == 0 || Status == 1) return true;
>>>>>>> origin/master
                return false;
            }
            public bool DateTimeChangeAllowed()
            {
<<<<<<< HEAD
                if (Status < 2) return true;
=======
                if (Status == 0 || Status == 1) return true;
>>>>>>> origin/master
                return false;
            }
            public bool DriverChangeAllowed()
            {
<<<<<<< HEAD
                if (Status < 2) return true;
=======
                if (Status == 0 || Status == 1) return true;
>>>>>>> origin/master
                return false;
            }
            public bool ClientChangeAllowed() {
                if (Status == 0) return true;
                return false;
            }
            public bool DriverMoneyChangeAllowed()
            {
<<<<<<< HEAD
                if (Status == 1) return true;
                return false;
=======
                if (Status == 0) return false;
                if (Status == 2) return false;
                if (Status == 3) return false;
                return true;
>>>>>>> origin/master
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
<<<<<<< HEAD
                    if (DispatcherController.AccessAllowed(conn, TheOrder) == false) continue;
=======
>>>>>>> origin/master
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

                String cmdQuery = "insert into \"Order\" (\"PK_Order\", \"PK_OrderStatus\", \"DateTime\", \"RegDateTime\", \"Sum\", \"Part\", \"PK_Driver\", \"PK_Client\", \"Address\", \"Countryside\", \"Comment\", \"PK_Dispatcher\")"
<<<<<<< HEAD
                    + " values (" + PK +","
=======
                         + " values ("+ PK +","
>>>>>>> origin/master
                         + TheOrder.Status + ","
                         + "to_date('" + (TheOrder.DateTime.ToString("dd-MM-yyyy HH:mm")) + "', 'dd-mm-yyyy hh24:mi'),"
                         + "to_date('" + (TheOrder.RegDateTime.ToString("dd-MM-yyyy HH:mm")) + "', 'dd-mm-yyyy hh24:mi'),"
                         + "'" + TheOrder.Sum + "',"
                         + "'" + TheOrder.Part + "',";
                if (TheOrder.PK_Driver > 0) cmdQuery += TheOrder.PK_Driver + ",";
                else cmdQuery += "null,";
                if (TheOrder.PK_Client > 0) cmdQuery += TheOrder.PK_Client + ",";
                else cmdQuery += "null,";
                cmdQuery += "'" + (TheOrder.Address.Replace("'", "`").Replace("\\","")) + "',"
                         + TheOrder.Countryside + ","
<<<<<<< HEAD
                         + "'" + (TheOrder.Comment.Replace("'", "`").Replace("\\","")) + "'";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += ",'" + (DispatcherController.ActiveDispatcher.PK_Dispathcer) + "'";
                else cmdQuery += ",null";
=======
                         + "'" + (TheOrder.Comment.Replace("'", "\\'")) + "'";
                cmdQuery += ",null";
>>>>>>> origin/master
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
                if (DispatcherController.AccessAllowed(conn, TheOrder) == false) return;
                String cmdQuery = "update \"Order\" set ";
                cmdQuery += "\"PK_OrderStatus\" = " + TheOrder.Status + ",";
                if (TheOrder.DateTimeChangeAllowed()) cmdQuery += "\"DateTime\" = to_date('" + (TheOrder.DateTime.ToString("dd-MM-yyyy HH:mm")) + "', 'dd-mm-yyyy hh24:mi'),";
                //cmdQuery += "\"RegDateTime\" = to_date('" + (TheOrder.RegDateTime.ToString("dd-MM-yyyy HH:mm")) + "', 'dd-mm-yyyy hh24:mi'),";
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
                    cmdQuery += "\"Address\" = '" + (TheOrder.Address.Replace("'", "`").Replace("\\","")) + "',";
                    cmdQuery += "\"Countryside\" = " + TheOrder.Countryside + ",";
                }
                cmdQuery += "\"Comment\" = '" + (TheOrder.Comment.Replace("'", "`").Replace("\\","")) + "' "
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
                if (DispatcherController.AccessAllowed(conn, TheOrder) == false) return;
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
                if (DispatcherController.AccessAllowed(conn, TheLine) == false) return;
                if (TheLine.Order != null && !TheLine.Order.LinesChangeAllowed()) return;
                String cmdQuery = "delete from \"OrderLine\" where \"PK_OrderLine\" = " + TheLine.PK_OrderLine;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void DeleteOrderLines(OracleConnection conn, Order TheOrder)
            {
                if (DispatcherController.AccessAllowed(conn, TheOrder) == false) return;
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

                return Sum;
            }
            public static float CountPart(float Sum, float Part)
            {
                return (float)((int)(Sum * Part + 0.5f));
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
                if (PK_Cafe <= 0) return GetDishList(conn, IncludeDisabled);

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
<<<<<<< HEAD
                        + (TheDish.Name.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheDish.Price.ToString()) + "','"
                        + (TheDish.PK_Cafe) + "',";
                if (!TheDish.Disabled) cmdQuery += "0)";
                else cmdQuery += "1)";
=======
                        + (TheDish.Name.Replace("'", "\\'")) + "','"
                        + (TheDish.Price.ToString()) + "','"
                        + (TheDish.PK_Cafe) + "',"
                        + "0)";
>>>>>>> origin/master
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateDish(OracleConnection conn, Dish TheDish)
            {
                String cmdQuery = "update \"Dish\" set " +
<<<<<<< HEAD
                    "\"Name\" = '" + (TheDish.Name.Replace("'", "`").Replace("\\","")) + "'," +
=======
                    "\"Name\" = '" + (TheDish.Name.Replace("'", "\\'")) + "'," +
>>>>>>> origin/master
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
            public int InState;

            public Driver()
            {
                PK_Driver = -1;
                Name = "";
                Phone = "";
                InState = 0;
            }

            public static Driver FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery1 = "select \"PK_Driver\", \"Name\", \"Phone\", \"InState\" from \"Driver\" where \"PK_Driver\" = " + PK;
                
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
                    if (!reader1.IsDBNull(3)) TheDriver.InState = reader1.GetInt32(3);

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
                String cmdQuery = "select \"PK_Driver\" from \"Driver\"";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Driver> Drivers = new List<Driver>();

                while (reader.Read())
                {
                    int PK_Driver = reader.GetInt32(0);
                    Driver TheDriver = Driver.FromPK(conn, PK_Driver);
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

<<<<<<< HEAD
                String cmdQuery = "insert into \"Driver\" (\"PK_Driver\", \"Name\", \"Phone\", \"InState\")"
                        + " values (" + PK + ",'"
                        + (TheDriver.Name.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheDriver.Phone.Replace("'", "`").Replace("\\","")) + "',"
                        + (TheDriver.InState) + ")";
=======
                String cmdQuery = "insert into \"Driver\" (\"PK_Driver\", \"Name\", \"Phone\")"
                        + " values (" + PK + ",'"
                        + (TheDriver.Name.Replace("'", "\\'")) + "','"
                        + (TheDriver.Phone.Replace("'", "\\'")) + "')";
>>>>>>> origin/master
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateDriver(OracleConnection conn, Driver TheDriver) {
                String cmdQuery = "update \"Driver\" set " +
<<<<<<< HEAD
                        "\"Name\" = '" + (TheDriver.Name.Replace("'", "`").Replace("\\","")) + "'," +
                        "\"Phone\" = '" + (TheDriver.Phone.Replace("'", "`").Replace("\\","")) + "'," +
                        "\"InState\" = " + TheDriver.InState + " " +
=======
                        "\"Name\" = '" + (TheDriver.Name.Replace("'", "\\'")) + "'," +
                        "\"Phone\" = '" + (TheDriver.Phone.Replace("'", "\\'")) + "'," +
>>>>>>> origin/master
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
                        + (TheClient.Name.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheClient.Phone.Replace("'", "`").Replace("\\","")) + "',"
                        + "'" + TheClient.Discount + "')";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateClient(OracleConnection conn, Client TheClient)
            {
                String cmdQuery = "update \"Client\" set " +
                        "\"Name\" = '" + (TheClient.Name.Replace("'", "`").Replace("\\","")) + "'," +
                        "\"Phone\" = '" + (TheClient.Phone.Replace("'", "`").Replace("\\","")) + "'," +
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
<<<<<<< HEAD
                        + (TheCafe.Name.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheCafe.Address.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheCafe.Phone.Replace("'", "`").Replace("\\","")) + "')";
=======
                        + (TheCafe.Name.Replace("'", "\\'")) + "','"
                        + (TheCafe.Address.Replace("'", "\\'")) + "','"
                        + (TheCafe.Phone.Replace("'", "\\'")) + "')";
>>>>>>> origin/master
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateCafe(OracleConnection conn, Cafe TheCafe) {
                String cmdQuery = "update \"Cafe\" set " +
<<<<<<< HEAD
                    "\"Name\" = '" + (TheCafe.Name.Replace("'", "`").Replace("\\","")) + "'," +
                    "\"Address\" = '" + (TheCafe.Address.Replace("'", "`").Replace("\\","")) + "'," +
                    "\"Phone\" = '" + (TheCafe.Phone.Replace("'", "`").Replace("\\","")) + "'" +
=======
                    "\"Name\" = '" + (TheCafe.Name.Replace("'", "\\'")) + "'," +
                    "\"Address\" = '" + (TheCafe.Address.Replace("'", "\\'")) + "'," +
                    "\"Phone\" = '" + (TheCafe.Phone.Replace("'", "\\'")) + "'" +
>>>>>>> origin/master
                    " where \"PK_Cafe\" = " + TheCafe.PK_Cafe;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateCafeMenu(OracleConnection conn, Cafe TheCafe, List<Dish> Dishes) {
                List<Dish> DishesToUpdate = new List<Dish>();
                List<Dish> DishesToAdd = new List<Dish>();
<<<<<<< HEAD
=======
                DisableDishes(conn, TheCafe);
>>>>>>> origin/master
                for (int i = 0; i < Dishes.Count; i++) {
                    if (Dishes[i].PK_Dish > 0) DishesToUpdate.Add(Dishes[i]);
                    else DishesToAdd.Add(Dishes[i]);
                }
                for (int i = 0; i < DishesToUpdate.Count; i++)
                {
                    DishController.UpdateDish(conn, DishesToUpdate[i]);
<<<<<<< HEAD
                }
                for (int i = 0; i < DishesToAdd.Count; i++)
                {
                    DishController.AddDish(conn, DishesToAdd[i]);
=======
                    DishController.EnableDish(conn, DishesToUpdate[i]);
                }
                for (int i = 0; i < DishesToAdd.Count; i++)
                {
                    DishController.UpdateDish(conn, DishesToAdd[i]);
                    DishController.EnableDish(conn, DishesToAdd[i]);
>>>>>>> origin/master
                }
            }
            public static void DisableDishes(OracleConnection conn, Cafe TheCafe) {
                List<Dish> Dishes = DishController.GetDishList(conn, false);
                for (int i = 0; i < Dishes.Count; i++) {
                    DishController.DisableDish(conn, Dishes[i]);
                }
            }
<<<<<<< HEAD
        }
        public class Dispatcher {
            public int PK_Dispathcer;
            public String Name;
            public String Login;
            public String Password;
            public int Banned;

            public Dispatcher() {
                PK_Dispathcer = -1;
                Name = "";
                Login = "";
                Password = "";
                Banned = 0;
            }
            public static Dispatcher FromPK(OracleConnection conn, int PK)
            {
                String cmdQuery = "select \"PK_Dispatcher\", \"Name\", \"Login\", \"Password\", \"Banned\" from \"Dispatcher\" where \"PK_Dispatcher\" = " + PK;

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Dispatcher TheDispatcher = new Dispatcher();
                    TheDispatcher.PK_Dispathcer = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheDispatcher.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) TheDispatcher.Login = reader.GetString(2);
                    if (!reader.IsDBNull(3)) TheDispatcher.Password = reader.GetString(3);
                    if (!reader.IsDBNull(4)) TheDispatcher.Banned = reader.GetInt32(4); else TheDispatcher.Banned = 0;

                    return TheDispatcher;
                }
                return null;
            }
            public static Dispatcher FromLogin(OracleConnection conn, String Login)
            {
                String cmdQuery = "select \"PK_Dispatcher\", \"Name\", \"Login\", \"Password\", \"Banned\" from \"Dispatcher\" where \"Login\" = '" + Login.Replace("'", "`").Replace("\\","")+"'";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Dispatcher TheDispatcher = new Dispatcher();
                    TheDispatcher.PK_Dispathcer = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) TheDispatcher.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) TheDispatcher.Login = reader.GetString(2);
                    if (!reader.IsDBNull(3)) TheDispatcher.Password = reader.GetString(3);
                    if (!reader.IsDBNull(4)) TheDispatcher.Banned = reader.GetInt32(4); else TheDispatcher.Banned = 0;

                    return TheDispatcher;
                }
                return null;
            }
        }
        public class DispatcherController {
            public static Dispatcher ActiveDispatcher = null;
            
            public static List<Dispatcher> GetDispatcherList(OracleConnection conn)
            {
                String cmdQuery = "select \"PK_Dispatcher\" from \"Dispatcher\"";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<Dispatcher> Dispatchers = new List<Dispatcher>();

                while (reader.Read())
                {
                    int PK_Dispatcher = reader.GetInt32(0);
                    Dispatcher TheDispatcher = Dispatcher.FromPK(conn, PK_Dispatcher);
                    Dispatchers.Add(TheDispatcher);
                }
                return Dispatchers;
            }

            public static void LogIn(OracleConnection conn, String Login, String Password) {
                Dispatcher TheDispatcher = Dispatcher.FromLogin(conn, Login);
                if (TheDispatcher == null)
                {
                    ActiveDispatcher = null;
                    return;
                }
                if (TheDispatcher.Banned != 0)
                {
                    ActiveDispatcher = null;
                    return;
                }
                if (TheDispatcher.Password.Replace("\\", "").Replace("'", "").Equals(Password.Replace("\\", "").Replace("'", "")) == false)
                {
                    ActiveDispatcher = null;
                    return;
                }
                ActiveDispatcher = TheDispatcher;
            }
            public static void LogOut(OracleConnection conn) {
                ActiveDispatcher = null;
            }

            public static bool AccessAllowed(OracleConnection conn, Order TheOrder) {
                if (ActiveDispatcher == null) return false;
                String cmdQuery = "select \"PK_Order\" from \"Order\" where \"PK_Order\" = '" + TheOrder.PK_Order + "' and \"PK_Dispatcher\" = '" + ActiveDispatcher.PK_Dispathcer + "'";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            public static bool AccessAllowed(OracleConnection conn, OrderLine TheLine)
            {
                if (ActiveDispatcher == null) return false;
                String cmdQuery = "select \"Order\".\"PK_Order\" from \"Order\", \"OrderLine\" where \"Order\".\"PK_Order\" = \"OrderLine\".\"PK_Order\" and \"OrderLine\".\"PK_OrderLine\" = '"+(TheLine.PK_OrderLine)+ "' and \"Order\".\"PK_Dispatcher\" = '" + ActiveDispatcher.PK_Dispathcer + "'";

                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }

            public static void AddDispatcher(OracleConnection conn, Dispatcher TheDispatcher)
            {
                String SEQ_Query = "select SEQ.NEXTVAL from dual";
                OracleCommand SEQcmd = new OracleCommand(SEQ_Query);
                SEQcmd.Connection = conn;
                SEQcmd.CommandType = CommandType.Text;
                OracleDataReader SEQreader = SEQcmd.ExecuteReader();
                SEQreader.Read();
                int PK = SEQreader.GetInt32(0);

                TheDispatcher.PK_Dispathcer = PK;

                String cmdQuery = "insert into \"Dispatcher\" (\"PK_Dispatcher\", \"Name\", \"Login\", \"Password\", \"Banned\")"
                        + " values (" + PK + ",'"
                        + (TheDispatcher.Name.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheDispatcher.Login.Replace("'", "`").Replace("\\","")) + "','"
                        + (TheDispatcher.Password.Replace("'", "`").Replace("\\","")) + "',"
                        + (TheDispatcher.Banned) + ")";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            public static void UpdateDispatcher(OracleConnection conn, Dispatcher TheDispatcher)
            {
                String cmdQuery = "update \"Dispatcher\" set " +
                    "\"Name\" = '" + (TheDispatcher.Name.Replace("'", "`").Replace("\\","")) + "'," +
                    "\"Login\" = '" + (TheDispatcher.Login.Replace("'", "`").Replace("\\","")) + "'," +
                    "\"Password\" = '" + (TheDispatcher.Password.Replace("'", "`").Replace("\\","")) + "', " +
                    "\"Banned\" = " + (TheDispatcher.Banned) +
                    " where \"PK_Dispatcher\" = " + TheDispatcher.PK_Dispathcer;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public class Statistics
        {
            public static int TotalOrders(OracleConnection conn, DateTime beg, DateTime end)
            {
                String cmdQuery = "select count(*) from \"Order\" where \"Order\".\"DateTime\" >= to_date('" + (beg.ToString("dd-MM-yyyy") + " 00:00") + "', 'dd-mm-yyyy hh24:mi') and \"Order\".\"DateTime\" <= to_date('" + (end.ToString("dd-MM-yyyy") + " 23:59") + "', 'dd-mm-yyyy hh24:mi')";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += " and \"Order\".\"PK_Dispatcher\" = " + (DispatcherController.ActiveDispatcher.PK_Dispathcer);
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(0)) return reader.GetInt32(0);
                return 0;
            }
            public static float AvgOrders(OracleConnection conn, DateTime beg, DateTime end)
            {
                int PeriodLength = ((int)((end - beg).TotalDays)) + 1;
                return (float)TotalOrders(conn, beg, end) / (float)PeriodLength;
            }
            public static float TotalProfit(OracleConnection conn, DateTime beg, DateTime end)
            {
                String cmdQuery = "select sum(\"Sum\") from \"Order\" where \"Order\".\"DateTime\" >= to_date('" + (beg.ToString("dd-MM-yyyy")+" 00:00") + "', 'dd-mm-yyyy hh24:mi') and \"Order\".\"DateTime\" <= to_date('" + (end.ToString("dd-MM-yyyy") + " 23:59") + "', 'dd-mm-yyyy hh24:mi')";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += " and \"Order\".\"PK_Dispatcher\" = " + (DispatcherController.ActiveDispatcher.PK_Dispathcer);
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(0)) return reader.GetFloat(0);
                return 0;
            }
            public static float AvgProfit(OracleConnection conn, DateTime beg, DateTime end)
            {
                int PeriodLength = ((int)((end - beg).TotalDays)) + 1;
                return (float)TotalProfit(conn, beg, end) / (float)PeriodLength;
            }

            public static List<object[]> ByDish(OracleConnection conn, DateTime beg, DateTime end)
            {
                String cmdQuery = "select \"OrderLine\".\"PK_Dish\", count(DISTINCT \"Order\".\"PK_Order\"), sum(\"OrderLine\".\"Cost\") from \"Order\", \"OrderLine\"" +
                    " where \"Order\".\"PK_Order\" = \"OrderLine\".\"PK_Order\"" +
                    " and \"Order\".\"DateTime\" >= to_date('" + (beg.ToString("dd-MM-yyyy")+" 00:00") + "', 'dd-mm-yyyy hh24:mi')" +
                    " and \"Order\".\"DateTime\" <= to_date('" + (end.ToString("dd-MM-yyyy")+" 23:59") + "', 'dd-mm-yyyy hh24:mi')";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += " and \"Order\".\"PK_Dispatcher\" = " + (DispatcherController.ActiveDispatcher.PK_Dispathcer);
                cmdQuery += " group by \"OrderLine\".\"PK_Dish\"";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<object[]> result = new List<object[]>();

                while (reader.Read())
                {
                    object[] line = new object[3];
                    if (!reader.IsDBNull(0)) line[0] = reader.GetInt32(0); else line[0] = null;
                    if (!reader.IsDBNull(1)) line[1] = reader.GetInt32(1); else line[1] = null;
                    if (!reader.IsDBNull(2)) line[2] = reader.GetFloat(2); else line[2] = null;
                    result.Add(line);
                }
                return result;
            }

            public static List<object[]> ByCafe(OracleConnection conn, DateTime beg, DateTime end)
            {
                String cmdQuery = "select \"Dish\".\"PK_Cafe\", count(DISTINCT \"Order\".\"PK_Order\"), sum(\"OrderLine\".\"Cost\") from \"Order\", \"OrderLine\", \"Dish\"" +
                    " where \"Order\".\"PK_Order\" = \"OrderLine\".\"PK_Order\" and \"OrderLine\".\"PK_Dish\" = \"Dish\".\"PK_Dish\"" +
                    " and \"Order\".\"DateTime\" >= to_date('" + (beg.ToString("dd-MM-yyyy") + " 00:00") + "', 'dd-mm-yyyy hh24:mi')" +
                    " and \"Order\".\"DateTime\" <= to_date('" + (end.ToString("dd-MM-yyyy") + " 23:59") + "', 'dd-mm-yyyy hh24:mi')";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += " and \"Order\".\"PK_Dispatcher\" = " + (DispatcherController.ActiveDispatcher.PK_Dispathcer);
                cmdQuery += " group by \"Dish\".\"PK_Cafe\"";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<object[]> result = new List<object[]>();

                while (reader.Read())
                {
                    object[] line = new object[3];
                    if (!reader.IsDBNull(0)) line[0] = reader.GetInt32(0); else line[0] = null;
                    if (!reader.IsDBNull(1)) line[1] = reader.GetInt32(1); else line[1] = null;
                    if (!reader.IsDBNull(2)) line[2] = reader.GetFloat(2); else line[2] = null;
                    result.Add(line);
                }
                return result;
            }

            public static List<object[]> ByClient(OracleConnection conn, DateTime beg, DateTime end)
            {
                String cmdQuery = "select \"Order\".\"PK_Client\", count(DISTINCT \"Order\".\"PK_Order\"), sum(\"Order\".\"Sum\") from \"Order\"" +
                    " where \"Order\".\"DateTime\" >= to_date('" + (beg.ToString("dd-MM-yyyy") + " 00:00") + "', 'dd-mm-yyyy hh24:mi')" +
                    " and \"Order\".\"DateTime\" <= to_date('" + (end.ToString("dd-MM-yyyy") + " 23:59") + "', 'dd-mm-yyyy hh24:mi')";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += " and \"Order\".\"PK_Dispatcher\" = " + (DispatcherController.ActiveDispatcher.PK_Dispathcer);
                cmdQuery += " group by \"Order\".\"PK_Client\"";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<object[]> result = new List<object[]>();

                while (reader.Read())
                {
                    object[] line = new object[3];
                    if (!reader.IsDBNull(0)) line[0] = reader.GetInt32(0); else line[0] = null;
                    if (!reader.IsDBNull(1)) line[1] = reader.GetInt32(1); else line[1] = null;
                    if (!reader.IsDBNull(2)) line[2] = reader.GetFloat(2); else line[2] = null;
                    result.Add(line);
                }
                return result;
            }
            public static List<object[]> ByDriver(OracleConnection conn, DateTime beg, DateTime end)
            {
                String cmdQuery = "select \"Order\".\"PK_Driver\", count(DISTINCT \"Order\".\"PK_Order\"), sum(\"Order\".\"Sum\") from \"Order\"" +
                    " where \"Order\".\"DateTime\" >= to_date('" + (beg.ToString("dd-MM-yyyy") + " 00:00") + "', 'dd-mm-yyyy hh24:mi')" +
                    " and \"Order\".\"DateTime\" <= to_date('" + (end.ToString("dd-MM-yyyy") + " 23:59") + "', 'dd-mm-yyyy hh24:mi')";
                if (DispatcherController.ActiveDispatcher != null) cmdQuery += " and \"Order\".\"PK_Dispatcher\" = " + (DispatcherController.ActiveDispatcher.PK_Dispathcer);
                cmdQuery += " group by \"Order\".\"PK_Driver\"";
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();

                List<object[]> result = new List<object[]>();

                while (reader.Read())
                {
                    object[] line = new object[3];
                    if (!reader.IsDBNull(0)) line[0] = reader.GetInt32(0); else line[0] = null;
                    if (!reader.IsDBNull(1)) line[1] = reader.GetInt32(1); else line[1] = null;
                    if (!reader.IsDBNull(2)) line[2] = reader.GetFloat(2); else line[2] = null;
                    result.Add(line);
                }
                return result;
            }
=======
>>>>>>> origin/master
        }
    }
}
