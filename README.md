# JobSchedule
基于Quartz.net 的Job调度框架

Quartz.NET是一个开源的作业调度框架，非常适合在平时的工作中，定时轮询数据库同步，定时邮件通知，定时处理数据等。 

Quartz.NET允许开发人员根据时间间隔（或天）来调度作业。它实现了作业和触发器的多对多关系，还能把多个作业与不同的触发器关联。

整合了 Quartz.NET的应用程序可以重用来自不同事件的作业，还可以为一个事件组合多个作业。

 

官方学习文档：http://www.quartz-scheduler.net/documentation/index.html

使用实例介绍：http://www.quartz-scheduler.net/documentation/quartz-2.x/quick-start.html

官方的源代码下载：http://sourceforge.net/projects/quartznet/files/quartznet/   


此项目是以前在实际业务场景中使用Quartz.net的场景：轮询操作数据

