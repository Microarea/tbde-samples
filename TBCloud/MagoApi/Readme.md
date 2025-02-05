# Task Builder Cloud : TBAPI Sample Code

This area contains sample code related to API exposed by TB plaform. We can find following folders:

* <b>MyApp</b>: a netcore application illustrating basic MagoAPI operations. Pay attention! Starting MagoCloud/MagoWeb 5.0 releases, this sample and related dependencies have been moved to .Net 8. This means that Net Framework compatibility is not supported any more. Furthermore, login operation will be performed as follows:
  * MagoWeb >= 5.0 version will use local MagoWeb console in order to perform login operations. 
  * MagoCloud >= 5.0 version will use local Gwam in order to perform login operations.
* <b>WFMagoCloudApi</b>: a Window Forms application illustrating basic MagoAPI operations. This sample uses .Net Framework 4.8.
