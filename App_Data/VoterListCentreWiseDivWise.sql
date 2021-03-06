/****** Script for SelectTopNRows command from SSMS  ******/
SELECT COUNT(*)
--,c.Comn_OfficeName
,O.Comn_OfficeName, D.Mem_DivisionName
  FROM [IEB].[dbo].[Mem_Vote_15_16_Voter_Final] as V
  inner join IEB.dbo.Mem_Member as M on M.Mem_MemberID=v.Mem_MemberID
  inner join IEB.dbo.Comn_Office as O on O.Comn_OfficeID=M.Comn_OfficeID
  inner join IEB.dbo.Comn_Office as C on O.UpperLabelOfficeID=C.Comn_OfficeID
  inner join IEB.dbo.Mem_SubDivision as S on S.Mem_SubDivisionID=M.Mem_SubDivisionID
  inner join IEB.dbo.Mem_Division as D on S.Mem_DivisionID=D.Mem_DivisionID
  group by --c.Comn_OfficeName,
  O.Comn_OfficeName
  , D.Mem_DivisionName
  order by --c.Comn_OfficeName,
  O.Comn_OfficeName
  , D.Mem_DivisionName