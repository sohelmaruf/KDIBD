/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  V.[no]
      ,case [paidFor] when 20 then 'LIFE' else 'Above 66' end
      ,V.[source]
      ,M.MembershipNo
      ,VL.NoInVoterList
      ,N.NewlyAddedRemarks
      ,M.Name
      ,D.Mem_DivisionName
  FROM [tmpcc].[dbo].[CEC_Life_Register_CurrentNo_Final] as V
  inner join IEB.dbo.Mem_Member as M on M.Mem_MemberID=V.no
  --inner join IEB.dbo.Comn_Office as O on M.Comn_OfficeID=O.Comn_OfficeID
  inner join IEB.dbo.Mem_SubDivision as S on M.Mem_SubDivisionID=S.Mem_SubDivisionID
  inner join IEB.dbo.Mem_Division as D on D.Mem_DivisionID=S.Mem_DivisionID
  left outer join IEB.dbo.Mem_Vote_15_16_Voter_Final as VL on M.Mem_MemberID=VL.Mem_MemberID
  left outer join  [tmpcc].[dbo].[MI_02_28_FinalVoterList] as N on M.Mem_MemberID =N.Mem_MemberID
  where  V.[no]  in (
  SELECT distinct [Mem_MemberID]
      
  FROM [IEB].[dbo].[Mem_Fees]
  where [Mem_FeesYearID] in (19,20)
  and paiddate <'2014-07-01'
  and [Comn_RowStatusID]=1
  )
  and  V.[no] not in (
  SELECT distinct [Mem_MemberID]
      
  FROM [IEB].[dbo].[Mem_Fees]
  where [Mem_FeesYearID] in (19,20)
  and paiddate >='2014-07-01'
  and [Comn_RowStatusID]=1
  )
  and  V.[no] in (select Mem_MemberID from Mem_Member where [Comn_RowStatusID]=1)
  order by V.no