using DATN.Data.Entities;
using DATN.InfrastructureLayer.Enums;
using System.Collections.Generic;
using System.Linq;

namespace DATN.DataAccessLayer.EF.SeedData
{
    public class SeeDatas
    {
        private readonly DATNDBContex _contex;

        public SeeDatas(DATNDBContex contex)
        {
            _contex = contex;
        }

        public void Seed()
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){ CategoryName = "Máy Ảnh",Active=true},
                new Category(){CategoryName = "Máy Quay",Active=true},
                new Category(){CategoryName = "Ống Kính",Active=false},
                new Category(){CategoryName = "Âm Thanh",Active=true},
                new Category(){CategoryName = "Phụ Kiện",Active=true},
                new Category(){CategoryName = "Đồng hồ",Active=false},
                new Category(){CategoryName = "Đồ Công Nghệ Khác",Active=true},
            };
            if (_contex.Categories.Count()==0)
            {
             
                _contex.Categories.AddRange(categories);
            }

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier(){CompanyName="SAMSUNG", Address = "BAC NINH"},
                new Supplier(){CompanyName="CANON", Address = "BAC NINH"},
                new Supplier(){CompanyName="NOKIA", Address = "BAC NINH"},
                new Supplier(){CompanyName="LG", Address = "BAC NINH"},
                new Supplier(){CompanyName="SONY", Address = "BAC NINH"},
            };
            if (_contex.Suppliers.Count() == 0)
            {
             
                _contex.Suppliers.AddRange(suppliers);
            }

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Máy Ảnh Canon Powershot SX620 HS - Đen",
                    Price = 20000000,
                    Sale = 15,
                    Inventory = 5,
                    Description = "Canon 6D Mark II Kit EF 24-105 F4L IS II USM  là chiếc máy ảnh cao cấp được nâng cấp từ người đàn anh Canon 6D đã được sản xuất từ năm 2012. Phiên bản mới được nâng cấp cảm biến ảnh full-frame với độ phân giải 26.2 MP tích hợp công nghệ lấy nét Dual Pixel cùng chip xử lý hình ảnh DIGIC 7. Canon cũng nâng cấp khả năng quay phim với chuẩn 1080p/60fps và tích hợp đầy đủ các kết nối Wi-Fi, Bluetooth, NFC và GPS vào trong một chiếc máy thuộc dòng cao cấp.",
                    Category = categories[1],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CCD",
                    PriceInput=10000000,
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy ảnh Canon EOS 6D Mark II",
                    Price = 18000000,
                    Sale = 10,
                    Inventory = 10,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[2],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CCD",
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    ISO = "9000",
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 6D Mark II",
                    Price = 15000000,
                    Sale = 0,
                    Inventory = 10,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[1],
                    Supplier = suppliers[3],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CMOS",
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 5D Mark IV",
                    Price = 30000000,
                    Sale = 15,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[2],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CMOS",
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Fujifilm X-T30 Mark II",
                    Price = 30000000,
                    Sale = 15,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CMOS",
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Fujifilm X-T30 Mark",
                    Price = 30000000,
                    Sale = 25,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CMOS",
                    ImageProcessor="HacoLED",
                    Screen = 5,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 90D Kit EF",
                    Price = 30000000,
                    Sale = 25,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "CMOS",
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 90D",
                    Price = 3000000,
                    Sale = 5,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "Medium Format",
                    ImageProcessor="HacoLED",
                    Screen = 4,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 90D",
                    Price = 30000000,
                    Sale = 10,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[0],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "Medium Format",
                    ImageProcessor="HacoLED",
                    Screen = 5,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 90D",
                    Price = 30000000,
                    Sale = 5,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[1],
                    Supplier = suppliers[2],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "Medium Format",
                    ImageProcessor="HacoLED",
                    Screen = 4,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
                new Product()
                {
                    Name = "Máy Ảnh Canon EOS 90D",
                    Price = 30000000,
                    Sale = 5,
                    Inventory = 4,
                    Description = "Canon là một trong hai thương hiệu lớn nhất trên thị trường máy ảnh DSLR. Tuy nhiên, những sản phẩm của Canon lại vô cùng đa dạng, làm cho người mua gặp nhiều bối rối khi lựa chọn. Hãy cùng Điện máy XANH tìm hiểu các dòng máy ảnh cơ DSRL của Canon và đối tượng sử dụng nhé!",
                    Category = categories[2],
                    Supplier = suppliers[1],
                    Insurance= 12,
                    Accessory="Pin, Sạc, Bao da",
                    Sensor = "Medium Format",
                    ImageProcessor="HacoLED",
                    Screen = 7,
                    PriceInput=10000000,
                    ShutterSpeed="1/250 giây"
                },
            };
            if (_contex.Products.Count() == 0)
            {
                
                _contex.Products.AddRange(products);
            }
            List<Payment> payments = new List<Payment>()
            {
                new Payment()
                {
                   PaymentType = PaymentType.CASH,
                   Allowed=true
                },
                new Payment()
                {
                   PaymentType = PaymentType.TRANSFER,
                   Allowed=true
                },
                new Payment()
                {
                   PaymentType = PaymentType.PAYPAL,
                   Allowed=true
                }
            };
            if (_contex.Payments.Count() == 0) 
            {
                _contex.Payments.AddRange(payments);
            }
            _contex.SaveChanges();
        }
    }
}