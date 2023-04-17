describe('Login tests', () => {
  it('opens login modal, inputs valid nickname, succeeds and redirects to home', () => {
    cy.visit('/')
    cy.contains('Zaloguj się').click()
    cy.get('input').type('Adam')
    cy.contains('Do dzieła').click()
    cy.url().should('contain', '/home')
  })
  it('opens login modal, inputs valid nickname, fails and shows error', () => {
    cy.visit('/')
    cy.contains('Zaloguj się').click()
    cy.get('input').type('Adam')
    cy.intercept('POST', '/api/Auth/Login?login=Adam', {
      statusCode: 500,
    }).as('call500')
    cy.contains('Do dzieła').click()
    cy.wait('@call500')
    cy.contains('Ups! Coś poszło nie tak.', { timeout: 10000 })
  })
  it('opens login modal, does not input nickname, shows error', () => {
    cy.visit('/')
    cy.contains('Zaloguj się').click()
    cy.contains('Do dzieła').click()
    cy.contains('Nazwa użytkownika nie może być pusta')
  })
})
