### Anforderungen (Use Cases):

1. **Use Case 1: Auftragsannahme**
   
   - Ein Fahrzeug erhält einen Transportauftrag mit den Informationen: Abfertigungs-Standort (VON), Ziel-Standort (NACH), und Liste der zu transportierenden Behälter.
   - Das Fahrzeug prüft, ob es über genügend freien Platz verfügt.
   - Das Fahrzeug prüft seine aktuelle Position im Verhältnis zum Abfertigungs-Standort.

2. **Use Case 2: Auftragsdurchführung**
   
   - Das Fahrzeug nimmt den Auftrag an und navigiert zum Abfertigungs-Standort.
   - Das Fahrzeug wird mit den Güterbehältern beladen.
   - Das Fahrzeug transportiert die Güter zum Ziel-Standort und wird dort entladen.

3. **Use Case 3: Kommunikation und Koordination**
   
   - Die Fahrzeuge tauschen untereinander und mit den Standorten Informationen über ihre aktuelle Position und Beladung über 5G aus.
   - Die Fahrzeuge aktualisieren ihren Status und ihre Position in Echtzeit.

### Testliste mit Test Cases:

#### Test Case 1: Erfolgreiche Auftragsannahme und -durchführung

- **Positivszenario**: Ein Fahrzeug mit ausreichend freiem Platz und der nächstgelegenen Position zum Abfertigungs-Standort erhält einen Auftrag, akzeptiert diesen, navigiert erfolgreich zum Abfertigungsstandort, wird korrekt beladen, transportiert die Güter zum Zielstandort und wird ordnungsgemäß entladen.

- **Negativszenario 1**: Ein Fahrzeug ohne ausreichenden freien Platz erhält einen Auftrag. Das Fahrzeug sollte den Auftrag ablehnen.

- **Negativszenario 2**: Ein Fahrzeug mit genügend freiem Platz, aber weit entfernt vom Abfertigungs-Standort erhält den Auftrag, während ein näheres Fahrzeug verfügbar ist. Das entferntere Fahrzeug sollte den Auftrag nicht annehmen.

#### Test Case 2: Auftragsdurchführung mit mehreren Aufträgen

- **Positivszenario**: Ein Fahrzeug mit ausreichendem Platz für mehrere Aufträge nimmt gleichzeitig zwei Aufträge an, die es logistisch sinnvoll kombinieren und nacheinander abwickeln kann.

- **Negativszenario 1**: Ein Fahrzeug nimmt mehr Aufträge an, als es basierend auf seinem freien Platz bewältigen kann. Das System sollte dies verhindern.

- **Negativszenario 2**: Ein Fahrzeug nimmt einen zweiten Auftrag an, dessen Zielort stark vom ersten abweicht, was zu ineffizienten Routen führt. Das System sollte die Annahme basierend auf der Routeneffizienz optimieren.

#### Test Case 3: Störung während der Auftragsdurchführung

- **Positivszenario**: Bei einer Störung (z.B. Fahrzeugausfall) kommuniziert das betroffene Fahrzeug den Vorfall, und ein anderes Fahrzeug übernimmt den Auftrag ohne erhebliche Verzögerungen.

- **Negativszenario 1**: Ein Fahrzeug fällt aus, und das System schafft es nicht, den Auftrag rechtzeitig einem anderen Fahrzeug zuzuweisen.

- **Negativszenario 2**: Ein Fahrzeug fällt aus, aber die Lastübernahme durch ein anderes Fahrzeug verursacht erhebliche Verzögerungen im Transportprozess.
