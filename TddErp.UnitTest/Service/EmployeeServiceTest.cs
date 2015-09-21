using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddErp.UnitTest.Service
{
    [TestClass]
    public class EmployeeServiceTest
    {
        //IQueryable<Employee> data;
        //IEmployeeService service;
        //IDbSet<Employee> dbSet;
        //IContext db;

        //public EmployeeServiceTest()
        //{
        //    data = new List<Employee>()
        //    {
        //        new Employee() { EmployeeID = "001" },
        //        new Employee() { EmployeeID = "002" },
        //        new Employee() { EmployeeID = "003" },
        //    }.AsQueryable();
        //    dbSe = Substitute.For<IDbSet<Employee>, DbSet<Employee>>().Initialize(data);
        //    db = Substitute.For<IContext>();
        //    db.Employee.Returns(dbSet);
        //    db.Set<Employee>().Returns(dbSet);
        //    service = new EmployeeService(db);
        //}

        //[TestMethod]
        //public void GetIdTest()
        //{
        //    var actual = service.GetId("003");
        //    actual.Should().Be("004");
        //}

        //[TestMethod]
        //public void GetByIdTest()
        //{
        //    var actual = service.GetById("003");
        //    actual.ShouldBeEquivalentTo(new Employee { EmployeeID = "003" });
        //}
    }
}