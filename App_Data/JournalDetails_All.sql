/****** Script for SelectTopNRows command from SSMS  ******/
SELECT JD.[ACC_JournalDetailID]
      ,JD.[JournalMasterID]
      ,JD.[ACC_ChartOfAccountLabel4ID]
      ,JD.[ACC_ChartOfAccountLabel3ID]
      ,JD.[WorkStation]
      ,JD.[Debit]
      ,JD.[Credit]
      ,JD.[ExtraField3]
      ,JD.[ExtraField2]
      ,JD.[ExtraField1]
      ,JD.[AddedBy]
      ,JD.[AddedDate]
      ,JD.[UpdatedBy]
      ,JD.[UpdatedDate]
      ,JD.[RowStatusID]
  FROM [WingsGlobal].[dbo].ACC_JournalMaster as JM
  inner join [ACC_JournalDetail] as JD on JD.[JournalMasterID] = JM.ACC_JournalMasterID
  inner join ACC_ChartOfAccountLabel4 as L4 on L4.ACC_ChartOfAccountLabel4ID=JD.ACC_ChartOfAccountLabel4ID
  inner join ACC_HeadType as HT on HT.ACC_HeadTypeID=L4.ACC_HeadTypeID
  inner join ACC_ChartOfAccountLabel3 as L3 on L3.ACC_ChartOfAccountLabel3ID=JD.ACC_ChartOfAccountLabel3ID
  inner join ACC_ChartOfAccountLabel2 as L2 on L2.ACC_ChartOfAccountLabel2ID=L3.ACC_ChartOfAccountLabel2ID
  inner join ACC_ChartOfAccountLabel1 as L1 on L2.ACC_ChartOfAccountLabel1ID=L1.ACC_ChartOfAccountLabel1ID
  