/****** Script for SelectTopNRows command from SSMS  ******/
SELECT Distinct Mobile
  FROM [IEB].[dbo].[Mem_Member]
  --inner join Mem_Vote_14_Voter on Mem_Vote_14_Voter.Mem_MemberID=[Mem_Member].Mem_MemberID
  inner join Mem_EducationalInfo on Mem_EducationalInfo.Mem_MemberID=[Mem_Member].Mem_MemberID
  where
    Len(Mobile) =11 
  and 
  Mem_EducationalInfo.YearOfPassing=1991
  and Mem_EducationalInfo.Comn_UniversityID=547
  order by Mobile
   --and Mem_Member.MemberShipNoDigit>=30000