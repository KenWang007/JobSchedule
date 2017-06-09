using JobSchedule.Entity;
using Quartz;
using System;

namespace JobSchedule.FlashItemOffline
{
    public class FlashItemOfflineJob : IJob
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        {
            log.Info("抢购商品到期上下线Job开启--------------");

            try
            {
                var processDataList = FlashItemOfflineDBHelper.GetOfflineFlashPromotion();

                if (processDataList != null && processDataList.Count > 0)
                {
                    foreach (var item in processDataList)
                    {
                        //就绪的活动并且已经到达开启时间自动开启
                        if (item.Status == (int)StatusEnum.FlashSaleStatusType.BeReady && item.PromotionStartTime <= DateTime.Now)
                        {
                            FlashItemOfflineDBHelper.UpdatePromotionStatus(item.SysNo, (int)StatusEnum.FlashSaleStatusType.Processing);

                            log.Info(string.Format("抢购商品到期上下线Job：活动已开启，活动编号：{0},活动名称：{1}--------------", item.SysNo, item.PromotionName));
                        }
                        //就绪的活动并且已经到达结束时间自动关闭
                        if (item.Status == (int)StatusEnum.FlashSaleStatusType.Processing && item.PromotionEndTime <= DateTime.Now)
                        {
                            FlashItemOfflineDBHelper.UpdatePromotionStatus(item.SysNo, (int)StatusEnum.FlashSaleStatusType.Finished);

                            log.Info(string.Format("抢购商品到期上下线Job：活动已到期关闭，活动编号：{0},活动名称：{1}--------------", item.SysNo, item.PromotionName));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("抢购商品到期上下线Job：执行出错，错误信息：" + ex.InnerException);
            }
        }
    }
} 
