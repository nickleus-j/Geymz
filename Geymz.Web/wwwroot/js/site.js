// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var audioContext = new (window.AudioContext || window.webkitAudioContext)();
function pingViaAudio(freq) {
    var oscillator = audioContext.createOscillator();
    var gainNode = audioContext.createGain();

    oscillator.connect(gainNode);
    gainNode.connect(audioContext.destination);

    oscillator.type = 'sine'; // Or 'triangle', 'square', 'sawtooth'
    oscillator.frequency.setValueAtTime(freq, audioContext.currentTime); // Frequency in Hz

    // Create a quick decay for a "ping" effect
    gainNode.gain.setValueAtTime(0.5, audioContext.currentTime); // Initial volume
    gainNode.gain.exponentialRampToValueAtTime(0.001, audioContext.currentTime + 0.3); // Decay over 0.3 seconds

    oscillator.start(audioContext.currentTime);
    oscillator.stop(audioContext.currentTime + 0.3); // Stop after the decay
}