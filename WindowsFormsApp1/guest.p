
/*------------------------------------------------------------------------
    File        : guest.p
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : achandranlalit
    Created     : Mon Apr 12 11:39:27 CEST 2021
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */

BLOCK-LEVEL ON ERROR UNDO, THROW.
DEFINE INPUT PARAMETER ipgastnr LIKE guest.gastnr NO-UNDO.
DEFINE OUTPUT PARAMETER opname LIKE guest.name NO-UNDO.
DEFINE OUTPUT PARAMETER opAddress AS CHARACTER NO-UNDO.
DEFINE OUTPUT PARAMETER opCountry AS CHARACTER NO-UNDO.

/* ********************  Preprocessor Definitions  ******************** */


/* ***************************  Main Block  *************************** */
/*OUTPUT TO 'C:\StartAllProgress\tmp\tmp.txt' APPEND.*/
/*PUT STRING (TIME, "HH:MM:SS") SKIP.                */
/*OUTPUT CLOSE.                                      */

FOR FIRST guest NO-LOCK WHERE guest.gastnr = ipgastnr:
  ASSIGN 
  opname = guest.name
  opAddress = guest.adresse1 + " " + guest.adresse2 + " " 
            + guest.adresse3 + " " + guest.adresse4
  opCountry = guest.land.
END.
IF NOT AVAILABLE guest THEN DO:
  ASSIGN 
    opName    = ""
    opAddress = ""
    opCountry = "".
END.

