# coding: shift_jis
while True:
     RHR = "RevolutionaryHostRoles\\"

     #��E�����
     RoleName = input("��E�� : ")
     Team = input("�w�c(�N���[or�C���|�X�^�[) : ")
#�\�[�X�R�[�h��������
     with open(RHR + "Patches\\RoleAssignment", "r", encoding="utf-8") as RAR:
          RA2 = RAR.read()
          if Team == "�N���[":
             TeamText = "crew"
          elif Team == "�C���|�X�^�[":
               TeamText = "imp"
          else:
              exit()
          with open(RHR + "Patches\\RoleAssignment", "w", encoding="utf-8"):
               text = RA2.replace(f"//{Team}", f"{TeamText}Settings.Add((byte)CustomRoleId.{RoleName} CustomOptionHolder.{RoleName}Option.GetSelection());\n            //{Team}")