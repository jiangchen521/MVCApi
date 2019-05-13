using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSDNTest.Models
{
    public class Test
    {
    }
    public class OrderInformation {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int OrderNum { get; set; }
        [Required]
        public DateTime OrderCreateTime { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }

    }

    public class CSDNTestData : DbContext {
        public CSDNTestData() : base("name = CSDNTestData")
        {

        }
        public DbSet<OrderInformation> OrderInformations { get; set; }
    }
    /// <summary>
    /// 用于上传参数的返回
    /// </summary>
    public class ResultData
    {
        public string Result { get; set; }
        public ErrorCode Code { get; set; }

    }

    public enum ErrorCode
    {
        OK,
        UserNotLogined,
        WrongParameter,
        UserNameExisted,
        PhoneNumberExisted,
        Exception //异常
    }
}