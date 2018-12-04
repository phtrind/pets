SELECT U.USU_CODIGO, 
       U.USU_NOME, 
       P.PET_NOME, 
       RE.RAC_NOME, 
       C.CID_NOME, 
       E.EST_SIGLA, 
       PTS.PTS_DESCRICAO AS SEXO, 
       PID.PID_DESCRICAO AS IDADE, 
       PPR.PPR_DESCRICAO AS PORTE, 
       P.PET_PESO, 
       COR1.COR_NOME AS COR_PRIMARIA, 
       COR2.COR_NOME AS COR_SECUNDARIA, 
       PPL.PPL_DESCRICAO AS PELO, 
       P.PET_VACINADO, 
       P.PET_VERMIFUGADO, 
       P.PET_CASTRADO, 
       P.PET_DESCRICAO, 
       L.LOC_LATITUDE, 
       L.LOC_LONGITUDE, 
       ANS.ANS_DESCRICAO,
	   ANT.ANT_DESCRICAO
FROM ANU_ANUNCIOS A
     INNER JOIN USU_USUARIOS U ON A.USU_CODIGO = U.USU_CODIGO
     INNER JOIN PET_PETS P ON A.PET_CODIGO = P.PET_CODIGO
     LEFT JOIN RAC_RACASESPECIES RE ON P.RAC_CODIGO = RE.RAC_CODIGO
     INNER JOIN CID_CIDADES C ON C.CID_CODIGO = A.CID_CODIGO
     INNER JOIN EST_ESTADOS E ON E.EST_CODIGO = A.EST_CODIGO
     LEFT JOIN PTS_PETSEXOS PTS ON PTS.PTS_CODIGO = P.PTS_CODIGO
     LEFT JOIN PID_PETIDADES PID ON PID.PID_CODIGO = P.PID_CODIGO
     INNER JOIN PPR_PETPORTES PPR ON PPR.PPR_CODIGO = P.PPR_CODIGO
     LEFT JOIN PPL_PETPELOS PPL ON PPL.PPL_CODIGO = P.PPL_CODIGO
     INNER JOIN COR_CORES COR1 ON COR1.COR_CODIGO = P.COR_PRIMARIA
     LEFT JOIN COR_CORES COR2 ON COR2.COR_CODIGO = P.COR_SECUNDARIA
     LEFT JOIN LOC_LOCALIZACOES L ON L.LOC_CODIGO = A.LOC_CODIGO
     INNER JOIN ANS_ANUNCIOSTATUS ANS ON A.ANS_CODIGO = ANS.ANS_CODIGO
	 INNER JOIN ANT_ANUNCIOTIPO ANT ON ANT.ANT_CODIGO = A.ANT_CODIGO
WHERE A.ANU_CODIGO = @IdAnuncio
AND ANS.ANS_CODIGO <> 1