SELECT RAC_CODIGO, 
       RAC_NOME
FROM RAC_RACASESPECIES
WHERE ANI_CODIGO = @IdAnimal
ORDER BY RAC_NOME