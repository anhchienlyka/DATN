using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.DataAccessLayer.EF.Migrations
{
    public partial class kooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE Pr_Get_Benefit(@startDate Date,@endDate Date,@option int)
                    as
                    begin
                    if @option=1
                    select DATEPART(DAY, o.CreateDate) as 'Ngay' , SUM(o.TotalCost) as 'Doanh Thu', ( SUM(o.TotalCost)- SUM(p.PriceInput*od.Quantity)) as 'Loi Nhuan' from Orders as o inner join OrderDetails as od on o.Id = od.OrderId join Products p on p.Id = od.ProductId
                    where o.TransacStatus= 3 AND @startDate<= o.CreateDate AND o.CreateDate <= @endDate
                    group by DATEPART(DAY, o.CreateDate);
                    if @option=2
                    select DATEPART(MONTH, o.CreateDate) as 'Thang' , SUM(o.TotalCost) as 'Doanh Thu', ( SUM(o.TotalCost)- SUM(p.PriceInput*od.Quantity)) as 'Loi Nhuan' from Orders as o inner join OrderDetails as od on o.Id = od.OrderId join Products p on p.Id = od.ProductId
                    where o.TransacStatus= 3 AND @startDate<= o.CreateDate AND o.CreateDate <= @endDate
                    group by DATEPART(MONTH, o.CreateDate);
                    if @option=3
                    select DATEPART(YEAR, o.CreateDate) as 'Nam' , SUM(o.TotalCost) as 'Doanh Thu', ( SUM(o.TotalCost)- SUM(p.PriceInput*od.Quantity)) as 'Loi Nhuan' from Orders as o inner join OrderDetails as od on o.Id = od.OrderId join Products p on p.Id = od.ProductId
                    where o.TransacStatus= 3 AND @startDate<= o.CreateDate AND o.CreateDate <= @endDate
                    group by DATEPART(YEAR, o.CreateDate);
                    end";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
