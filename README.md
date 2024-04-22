# Wiskunde Keuzedeel #1
## Endless Runner in Unity

In dit project maak ik een endless runner met behulp van wiskundige formules, in dit geval de parabool en sinus.

## Parabolen
De player gebruikt een `ParabolicFunction`, deze can gecalled worden door middel van zijn constructer

De parabool gebruik ik door de formule ``InitialHeight + (InitialVelocity * t) - (0.5f * Gravity * t * t)`` in code. De `ParabolicFunction` heeft ook nog een `timeToZero` method die kijkt waar het grootste nulpunt ligt op de lijn, deze formule is ``(InitialVelocity + Mathf.Sqrt(InitialVelocity * InitialVelocity + 2 * Gravity * InitialHeight)) / Gravity`` in code. Dit is de parabool ingevult in Desmos:
![parabool](https://github.com/ferrondw/wiskunde-keuzedeel/assets/145978195/6008c444-b85c-42fe-aeaa-60cb4d7e0da8)

## Sinus
Om het een échte platformer te maken heb ik ook nog muntjes toegevoegd. Deze gebruiken de sinus om omhoog en naar beneden te bewegen. I.p.v. dat ik simpelweg de `Mathf.Sin` gebruik heb ik net zoals de `ParabolicFunction` een cunstructer gemaakt die een `Amplitude` en `Frequency` neemt. Deze is ``Amplitude * (float)Math.Sin(2 * Math.PI * Frequency * x)`` in code. Deze heb ik ook uitgeprobeerd in desmos:
![image](https://github.com/ferrondw/wiskunde-keuzedeel/assets/145978195/73501384-c9ca-498b-9900-aedc9503e9c5)

De rest van de uitleg staat in de scripts zelf, heb HEEL VEEL comments achter gelaten! (Kijk vooral naar de Platform, die heeft een hele custom collision system >:D )
