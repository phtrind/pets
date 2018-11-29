SELECT ANU.ANU_CODIGO, 
       PET.PET_NOME, 
	   ANI.ANI_NOME,
       RAC.RAC_NOME, 
	   ANT.ANT_DESCRICAO,
       ANU.ANU_DTHCADASTRO, 
       ANS.ANS_DESCRICAO, 
(
    SELECT COUNT(*)
    FROM AVI_ANUNCIOSVISITAS
    WHERE ANU_CODIGO = ANU.ANU_CODIGO
) AS VISUALIZACOES, 
(
    SELECT COUNT(*)
    FROM INT_INTERESSES
    WHERE ANU_CODIGO = ANU.ANU_CODIGO
) AS INTERESSADOS
FROM ANU_ANUNCIOS ANU
     INNER JOIN PET_PETS PET ON ANU.PET_CODIGO = PET.PET_CODIGO
	 INNER JOIN ANI_ANIMAIS ANI ON PET.ANI_CODIGO = ANI.ANI_CODIGO
     INNER JOIN RAC_RACASESPECIES RAC ON PET.RAC_CODIGO = RAC.RAC_CODIGO
	 INNER JOIN ANT_ANUNCIOTIPO ANT ON ANU.ANT_CODIGO = ANT.ANT_CODIGO
     INNER JOIN ANS_ANUNCIOSTATUS ANS ON ANU.ANS_CODIGO = ANS.ANS_CODIGO
WHERE ANU.USU_CODIGO = @IdUsuario