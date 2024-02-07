using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a PokeBall that releases a random Pokemon when colliding with the ground.
/// </summary>
public class PokeBall : MonoBehaviour
{
    /// <summary>
    /// Animator for the PokeBall.
    /// </summary>
    public Animator anim;

    /// <summary>
    /// List of Pokemon prefabs that can be spawned.
    /// </summary>
    public List<GameObject> pokemons;

    /// <summary>
    /// Index of the randomly chosen Pokemon.
    /// </summary>
    private int randomPokemonIndex;

    /// <summary>
    /// Called when the PokeBall collides with another collider.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            OpenPokeBall();
        }
    }

    /// <summary>
    /// Opens the PokeBall, spawns a random Pokemon, and schedules the destruction of the PokeBall and the spawned Pokemon.
    /// </summary>
    private void OpenPokeBall()
    {
        anim.Play("BallOpen");

        // Randomly choose a Pokemon from the list
        randomPokemonIndex = Random.Range(0, pokemons.Count);

        // Instantiate and position the chosen Pokemon
        GameObject spawnedPokemon = GameObject.Instantiate(pokemons[randomPokemonIndex], transform.position, Quaternion.identity);

        // Disable the collider of the PokeBall
        GetComponent<Collider>().enabled = false;

        // Destroy the PokeBall and the spawned Pokemon after a delay
        Destroy(this.gameObject, 2f);
        Destroy(spawnedPokemon, 6f);
    }
}
