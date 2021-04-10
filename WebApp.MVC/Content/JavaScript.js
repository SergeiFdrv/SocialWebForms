function setUserPopupDisplay(value) {
	document.getElementById('userpopup').style.display = value;
	console.log('#userpopup { display: ' + value + '; }');
}

function onMouseOut(event) {
	//this is the original element the event handler was assigned to
	var e = event.toElement || event.relatedTarget;
	if (e?.parentNode == this || e == this) {
		return;
	}
	console.log(event);
	// handle mouse event here!
	setUserPopupDisplay('none');
}
document.getElementById('userpopup')?.addEventListener('mouseout', onMouseOut, true);
































/*
 * Migrations.
PM> Add-Migration WebAppMigration -OutputDir "Data/Migrations"
PM> Update-Database
PM> Update-Database 0
PM> Remove-Migration
PM> 
 */

/*
 * BCrypt.
C#:
using BCrypt.Net;

public class Hashing
{
	private static string GetRandomSalt()
	{
		return BCrypt.GenerateSalt(12);
	}

	public static string HashPassword(string password)
	{
		return BCrypt.HashPassword(password, GetRandomSalt());
	}

	public static bool ValidatePassword(string password, string correctHash)
	{
		return BCrypt.Verify(password, correctHash);
	}
}
 */