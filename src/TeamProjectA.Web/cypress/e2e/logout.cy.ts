describe('Logout tests', () => {
  it('clicks logout button, redirects to landing page', () => {
    const validJWT =
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyLCJleHAiOjI1MTYyMzkwMjJ9.d9Bbx_4LikUHETu6aK5c4b-gO3PA8rzrIU2JwHna__s'

    localStorage.setItem('userToken', validJWT)

    cy.visit('/home')
    cy.get('.v-navigation-drawer').trigger('mouseenter')
    cy.contains('Wyloguj').click()
    cy.url().should('equal', 'http://localhost:5173/')
  })
})
