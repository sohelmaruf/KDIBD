SELECT     
Mem_Vote_15_16_Voter_Final.NoInVoterList, 
Mem_Member.Name, 
Mem_Member.MailingAddress1+''+ 
Mem_Member.MailingAddress2+''+ 
Mem_Member.MailingAddress3, 
Mem_Member.Mobile, 
Mem_Member.Email, 
Mem_Member.PresentIEBMembershipNo, 
Mem_Division.Mem_DivisionName, 
Comn_University.Comn_UniversityName, 
Comn_Office.Comn_OfficeName, 
Mem_Member.ExtraField2 as Job, 
Mem_Member.ExtraField17 as PassingYear, 
Mem_Member.ExtraField18 as  Unv

FROM         
Mem_Member  INNER JOIN
                      Mem_Vote_15_16_Voter_Final ON Mem_Vote_15_16_Voter_Final.Mem_MemberID = Mem_Member.Mem_MemberID  
   LEFT outer JOIN
Comn_Nationality ON Mem_Member.Comn_NationalityID = Comn_Nationality.Comn_NationalityID LEFT outer JOIN
Comn_Gender ON Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID LEFT outer JOIN
Mem_SubDivision ON Mem_Member.Mem_SubDivisionID = Mem_SubDivision.Mem_SubDivisionID LEFT outer JOIN
Mem_Division ON Mem_SubDivision.Mem_DivisionID = Mem_Division.Mem_DivisionID LEFT outer JOIN
Mem_ApprovedCouncilMeeting ON 
Mem_Member.Mem_ApprovedCouncilMeetingID = Mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingID LEFT outer JOIN
Comn_Status ON Mem_Member.Comn_StatusID = Comn_Status.Comn_StatusID LEFT outer JOIN
Comn_University ON Mem_Member.Comn_UniversityID = Comn_University.Comn_UniversityID LEFT outer JOIN
Comn_Office ON Mem_Member.Comn_OfficeID = Comn_Office.Comn_OfficeID  LEFT outer JOIN
Comn_RowStatus ON Mem_Member.Comn_RowStatusID = Comn_RowStatus.Comn_RowStatusID
