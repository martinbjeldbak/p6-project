using System;
using Simple.Data;
using Simple.Data.PostgreSql;
using System.Configuration;


namespace DBTesting {
  class MainClass {
    class Name {
      private string firstName;

      public string FirstName {
        get {
          return firstName;
        }
        set {
          firstName = value;
        }
      }
    }

    class Jesus {
      private int age;
      private Name name;

      public Name Name {
        get {
          return name;
        }
        set {
          name = value;
        }
      }

      public Jesus() {
        name = new Name();
      }

      public int Age {
        get {
          return age;
        }
        set {
          age = value;
        }
      }
    }


    public static void Main(string[] args) {
      //testPerson();
      testInsertion();
    }

    public static void testInsertion() {
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string port = "5432";
      string dbName = "gannai";
      string user = "d601f14";
      string pass = "p6d601f14";

      string connString = String.Format("Server={0};Port={1};" +
        "User Id={2};Password={3};Database={4};",
        server, port, user, pass, dbName);


      var db = Database.OpenConnection(connString);

      Jesus elias = new Jesus();
      elias.Name.FirstName = "Elias";

      db.Jesus.Insert(elias, firstName: "Loool fail");
    }

    public static void testPerson() {
      string server = "p6project.cfahefdbp8px.us-west-2.rds.amazonaws.com";
      string port = "5432";
      string dbName = "gannai";
      string user = "d601f14";
      string pass = "p6d601f14";

      string connString = String.Format("Server={0};Port={1};" +
        "User Id={2};Password={3};Database={4};",
        server, port, user, pass, dbName);



      var db = Database.OpenConnection(connString);

      var tests = db.Tests.All();

      foreach(var person in tests) {
        Console.WriteLine(person.person_id);
      }

    }
  }
}
