using CSDNTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSDNTest.Services
{
    public class OrderService
    {
        private readonly CSDNTestData _testDB = new CSDNTestData();
        /// <summary>
        /// 订单状态更新
        /// </summary>
        /// <returns></returns>
        public ResultData UpdateOrderInfos(OrderInformation state)
        {
            try
            {
                var searchResult = _testDB.OrderInformations.Where(p => p.OrderID == state.OrderID).AsNoTracking().FirstOrDefault();
                //客户追加产品，并假设下单时间、交货时间和规格仍依第一次下单为基准，只叠加数量
                if (searchResult != null)
                {
                    var sumNum = searchResult.OrderNum + state.OrderNum;
                    OrderInformation order = new OrderInformation() {
                        OrderID = searchResult.OrderID,
                        Size = searchResult.Size,
                        DeliveryTime = searchResult.DeliveryTime,
                        OrderCreateTime = searchResult.OrderCreateTime,
                        OrderNum = sumNum,
                        UserName = searchResult.UserName,
                    };
                    _testDB.Entry<OrderInformation>(order).State = EntityState.Modified;
                }
                //客户第一次下单
                else {
                    _testDB.OrderInformations.Add(state);
                }
                _testDB.SaveChanges();
                return new ResultData()
                {
                    Result = "OK",
                    Code = ErrorCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultData()
                {
                    Result = "Error",
                    Code = ErrorCode.Exception
                };
            }
        }
    }
}