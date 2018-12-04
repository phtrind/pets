SELECT INTE.INT_CODIGO, 
       ANU.ANU_CODIGO, 
       PET.PET_NOME, 
       ANI.ANI_NOME, 
       RAC.RAC_NOME, 
       INTE.INT_DTHCADASTRO, 
       ANT.ANT_DESCRICAO, 
       USU.USU_NOME,
	   INS.INS_DESCRICAO
FROM INT_INTERESSES INTE
     INNER JOIN ANU_ANUNCIOS ANU ON INTE.ANU_CODIGO = ANU.ANU_CODIGO
     INNER JOIN PET_PETS PET ON ANU.PET_CODIGO = PET.PET_CODIGO
     LEFT JOIN ANI_ANIMAIS ANI ON PET.ANI_CODIGO = ANI.ANI_CODIGO
     LEFT JOIN RAC_RACASESPECIES RAC ON PET.RAC_CODIGO = RAC.RAC_CODIGO
     INNER JOIN ANT_ANUNCIOTIPO ANT ON ANU.ANT_CODIGO = ANT.ANT_CODIGO
     INNER JOIN USU_USUARIOS USU ON ANU.USU_CODIGO = USU.USU_CODIGO
	 INNER JOIN INS_INTERESSESTATUS INS ON INTE.INS_CODIGO = INS.INS_CODIGO
WHERE INTE.USU_CODIGO = @IdUsuario