UPDATE ANF_ANUNCIOFOTOS
  SET 
      ANF_DESTAQUE = 0
WHERE ANU_CODIGO =
(
    SELECT ANU_CODIGO
    FROM ANF_ANUNCIOFOTOS
    WHERE ANF_CODIGO = @IdFoto
);

UPDATE ANF_ANUNCIOFOTOS
  SET 
      ANF_DESTAQUE = 1
WHERE ANF_CODIGO = @IdFoto